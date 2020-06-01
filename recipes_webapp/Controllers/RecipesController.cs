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

            using (Db db = new Db())
            {
                DishesList = db.Dishes.ToArray().Select(x => new DishesVM(x)).ToList();
            }

            // DishesList = db.Dishes.ToArray().Select(x => new DishesVM(x)).Where(x => x.Name.Contains(searching) || searching == null).ToList();
        
            return View(DishesList);
            //return View(db.Dishes.Where(x => x.Name.Contains(searching) || searching == null).ToList());
        }

    }

}