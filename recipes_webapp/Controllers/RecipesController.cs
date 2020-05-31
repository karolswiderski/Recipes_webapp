using recipes_webapp.Models.DTO;
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
        public ActionResult Index()
        {
            List<DishesVM> DishesList;

            using (Db db = new Db())
            {
                DishesList = db.Dishes.ToArray().Select(x => new DishesVM(x)).ToList();
            }

            return View(DishesList);
        }
    }
}