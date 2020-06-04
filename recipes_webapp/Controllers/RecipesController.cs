using recipes_webapp.Models.Data;
using recipes_webapp.Models.ViewModels.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace recipes_webapp.Controllers
{
    public class RecipesController : Controller
    {
        // GET: Recipes/
        public ActionResult Index(string searching)
        {
            //Console.WriteLine("searching: " + searching);
            //Console.WriteLine("categoryName: " + categoryName);
            if (TempData["categoryName"].ToString() != null) {
            
}
            string categoryName = TempData["categoryName"].ToString();
            List<DishesVM> DishesList;

            if (string.IsNullOrEmpty(searching))
            {
                using (Db db = new Db())
                {
                    if (categoryName == null) DishesList = db.Dishes.ToArray().Select(x => new DishesVM(x)).ToList();
                    else
                    {
                        CategoriesDTO category = db.Categories.FirstOrDefault(x => x.Name == categoryName);
                        DishesList = db.Dishes.Where(x => x.Id_Category == category.Id_Category).ToArray().Select(x => new DishesVM(x)).ToList();
                    }
                }
            }
            else {
                using (Db db = new Db())
                {
                    if (categoryName == null) DishesList = db.Dishes.ToArray().Where(x => x.Name.StartsWith(searching) || searching == null).Select(x => new DishesVM(x)).ToList();
                    else
                    {
                        CategoriesDTO category = db.Categories.FirstOrDefault(x => x.Name == categoryName);
                        DishesList = db.Dishes.ToArray().Where(x => x.Name.StartsWith(searching) || searching == null && x.Id_Category == category.Id_Category).Select(x => new DishesVM(x)).ToList();
                    } 
                }
            }

            return View(DishesList);
        }

        // GET: Recipes/Categories/name
        public void Categories(string name)
        {
            // return RedirectToAction("Index", new { searching = "", categoryName = name});
            TempData["categoryName"] = name;
        }

        public ActionResult ListOfCategories() {
            List<CategoriesVM> CategoriesList;
            using (Db db = new Db())
            {
                CategoriesList = db.Categories.ToArray().Select(x => new CategoriesVM(x)).ToList();
            }
            return PartialView(CategoriesList);
        }

        
        
    }

}