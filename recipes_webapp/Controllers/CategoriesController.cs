using recipes_webapp.Models.Data;
using recipes_webapp.Models.ViewModels.Account;
using recipes_webapp.Models.ViewModels.Dishes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace recipes_webapp.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories/
        [HttpGet]
        public ActionResult Index(string categoryName, bool flag = false)
        {
            List<CategoriesVM> CategoriesList;
            if (flag == false)
            {
                TempData["categoryName"] = "all";
            }
            else
            {
                TempData["categoryName"] = categoryName;
            }

            using (Db db = new Db())
            {
                CategoriesList = db.Categories.ToArray().Select(x => new CategoriesVM(x)).ToList();
            }
            return View(CategoriesList);
        }

        [HttpGet]
        public ActionResult Recipes(string name)
        {
            List<DishesVM> DishesList;

            using (Db db = new Db())
            {
                if (name == "all") DishesList = db.Dishes.ToArray().Select(x => new DishesVM(x)).ToList();
                else
                {
                    CategoriesDTO category = db.Categories.FirstOrDefault(x => x.Name == name);
                    TempData["test"] = "test";
                    DishesList = db.Dishes.Where(x => x.Id_Category == category.Id_Category).ToArray().Select(x => new DishesVM(x)).ToList();
                }
            }

            return PartialView(DishesList);
        }

        [HttpGet]
        public ActionResult BestRating(string name, int userId)
        {
            List<DishesVM> DishesList = new List<DishesVM>();

            using (Db db = new Db())
            {
                if (name == "byuserid" || name == "following")
                {
                    if (name == "byuserid") DishesList = db.Dishes.Where(x => x.Id_Author == userId).ToArray().Select(x => new DishesVM(x)).OrderBy(x => x.Rating).ToList();
                    else if (name == "following")
                    {
                        List<int> followingList = db.Recipe_Followers.Where(x => x.Follower_Id == userId && x.Its_Still == true).ToArray().Select(x => x.Recipe_Id).ToList();
                        foreach (var item in followingList)
                        {
                            DishesDTO dish = new DishesDTO();
                            dish = db.Dishes.First(x => x.Id_Dish == item);
                            DishesList.Add(new DishesVM(dish));
                        }
                    }
                }
                else
                {
                    if (name == "all") DishesList = db.Dishes.ToArray().Select(x => new DishesVM(x)).OrderBy(x => x.Rating).Take(6).ToList(); 
                    else if (name != "all" && name != "byuserid")
                    {
                        CategoriesDTO category = db.Categories.FirstOrDefault(x => x.Name == name);
                        TempData["test"] = "test";
                        DishesList = db.Dishes.Where(x => x.Id_Category == category.Id_Category).ToArray().Select(x => new DishesVM(x)).OrderBy(x => x.Rating).ToList();
                    }
                }
                foreach (var item in DishesList)
                {
                    item.MyGallery = Directory.EnumerateFiles(Server.MapPath("~/Content/Images/Uploads/Recipes/" + item.Id_Dish + "/Gallery")).Select(fn => Path.GetFileName(fn));
                }
            }

            return PartialView(DishesList);
        }

        [HttpGet]
        public ActionResult TopNavBarCategories()
        {

            List<CategoriesVM> CategoriesList;
            using (Db db = new Db())
            {
                CategoriesList = db.Categories.ToArray().Select(x => new CategoriesVM(x)).ToList();
            }

            return PartialView(CategoriesList);
        }
    }
}