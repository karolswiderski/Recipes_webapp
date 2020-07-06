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
            DishesVM recipeVM;
            TempData["categoryName"] = "";
            TempData["userName"] = "";

            using (Db db = new Db())
            {
                DishesDTO recipeDTO = db.Dishes.Find(id);
                recipeVM = new DishesVM(recipeDTO);
                TempData["categoryName"] = db.Categories.Where(x => x.Id_Category == recipeVM.Id_Category).Select(x => x.Name).SingleOrDefault();
            }


           return View(recipeVM);
        }

        [HttpGet]
        public ActionResult PhotoSlider(int id) {

            GalleryVM galleryVM;

            using (Db db = new Db())
            {
                GalleryDTO galleryDTO = db.Gallery.Find(id);
                galleryVM = new GalleryVM(galleryDTO);
            }

                return PartialView(galleryVM);
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
                directionsDTO = db.Directions.Find(id);
                directionsVM = new DirectionsVM(directionsDTO);
            }

                return PartialView(directionsVM);
        }

        [HttpGet]
        public ActionResult AddNew() {
            AddNewRecipeVM model = new AddNewRecipeVM();

            return View(model);
        }
    }
}