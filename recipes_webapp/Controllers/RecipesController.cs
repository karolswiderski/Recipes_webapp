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
        // GET: Recipes
        public ActionResult Index(string searching)
        {
            List<DishesVM> DishesList;

            if (string.IsNullOrEmpty(searching))
            {
                using (Db db = new Db())
                {
                    DishesList = db.Dishes.ToArray().Select(x => new DishesVM(x)).ToList();
                }
            }
            else {
                using (Db db = new Db())
                {
                    DishesList = db.Dishes.ToArray().Where(x => x.Name.StartsWith(searching) || searching == null).Select(x => new DishesVM(x)).ToList();
                }
            }

            return View(DishesList);
        }

        // GET: recipes/aa
        public ActionResult aa()
        {
            List<CategoriesVM> l;

            using (Db db = new Db())
            {
                l = db.Categories.ToArray().Select(x => new CategoriesVM(x)).ToList();
            }

            return View(l);
        }

    }

}