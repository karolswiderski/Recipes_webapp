using recipes_webapp.Models.Data;
using recipes_webapp.Models.ViewModels.Dishes;
using System;
using System.Collections.Generic;
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
                if (name == "byuserid")
                {
                    DishesList = db.Dishes.Where(x => x.Id_Author == userId).ToArray().Select(x => new DishesVM(x)).OrderBy(x => x.Rating).ToList();
                }
                else
                {
                    if (name == "all") DishesList = db.Dishes.ToArray().Select(x => new DishesVM(x)).OrderBy(x => x.Rating).ToList();
                    else if (name != "all" && name != "byuserid")
                    {
                        CategoriesDTO category = db.Categories.FirstOrDefault(x => x.Name == name);
                        TempData["test"] = "test";
                        DishesList = db.Dishes.Where(x => x.Id_Category == category.Id_Category).ToArray().Select(x => new DishesVM(x)).OrderBy(x => x.Rating).ToList();
                    }
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