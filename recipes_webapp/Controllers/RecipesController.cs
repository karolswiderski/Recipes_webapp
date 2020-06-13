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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Recipes/Details
        public ActionResult Details(int id)
        {
            DishesDTO recipeDTO;
            DishesVM recipeVM;

            using (Db db = new Db())
            {
                recipeDTO = db.Dishes.Where(x => x.Id_Dish == id).FirstOrDefault();
                recipeVM = new DishesVM(recipeDTO);
            }


           return View(recipeVM);
        }

        [HttpGet]
        public ActionResult Ingredients(int id)
        {
            //List<string> ingredientsList;
            IngredientsVM ingredientsVM;
            IngredientsDTO ingredientsDTO;

            using (Db db = new Db())
            {
                ingredientsDTO = db.Ingredients.Where(x => x.Id_Ingredient == id).FirstOrDefault();
                ingredientsVM = new IngredientsVM(ingredientsDTO);

                
            }

            return PartialView(ingredientsVM);
        }

        [HttpGet]
        public ActionResult Directions(int id)
        {
            DirectionsVM directionsVM;
            DirectionsDTO directionsDTO;

            using (Db db = new Db())
            {
                directionsDTO = db.Directions.Where(x => x.Id_Direction == id).FirstOrDefault();
                directionsVM = new DirectionsVM(directionsDTO);
            }

                return PartialView(directionsVM);
        }
    }
}