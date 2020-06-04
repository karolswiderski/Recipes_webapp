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
        // GET: Categories/All/
        [HttpGet]
        public ActionResult All(string categoryName, bool flag = false)
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
            
            using(Db db = new Db())
            {
                CategoriesList = db.Categories.ToArray().Select(x => new CategoriesVM(x)).ToList();
            }
            return View(CategoriesList);
        }
        

        [HttpGet]
        public ActionResult Recipes(string searching, string name)
        {
            List<DishesVM> DishesList;

            if (string.IsNullOrEmpty(searching))
            {
                using (Db db = new Db())
                {
                    if (name == "all") DishesList = db.Dishes.ToArray().Select(x => new DishesVM(x)).ToList();
                    else
                    {
                        CategoriesDTO category = db.Categories.FirstOrDefault(x => x.Name == name);
                        DishesList = db.Dishes.Where(x => x.Id_Category == category.Id_Category).ToArray().Select(x => new DishesVM(x)).ToList();
                    }
                }
            }
            else
            {
                using (Db db = new Db())
                {
                    if (name == "all") DishesList = db.Dishes.ToArray().Where(x => x.Name.StartsWith(searching) || searching == null).Select(x => new DishesVM(x)).ToList();
                    else
                    {
                        CategoriesDTO category = db.Categories.FirstOrDefault(x => x.Name == name);
                        DishesList = db.Dishes.ToArray().Where(x => x.Name.StartsWith(searching) || searching == null && x.Id_Category == category.Id_Category).Select(x => new DishesVM(x)).ToList();
                    }
                }
            }

            return PartialView(DishesList);
        }
    }
}