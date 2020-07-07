using recipes_webapp.Models.Class;
using recipes_webapp.Models.Data;
using recipes_webapp.Models.ViewModels.Dishes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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

            List<Level> level= new List<Level>();
            level.Add(new Level() { Level_Id = 1, Level_Name = "Łatwy" });
            level.Add(new Level() { Level_Id = 2, Level_Name = "Średni" });
            level.Add(new Level() { Level_Id = 3, Level_Name = "Trudny" });

            AddNewRecipeVM model = new AddNewRecipeVM();
            using (Db db = new Db()) {
                model.CategoriesList = new SelectList(db.Categories.ToList(), "Id_Category", "Name");
                model.LevelList = new SelectList(level, "Level_Id", "Level_Name");
            }
                return View(model);
        }

        // POST: Home/SaveGalleryImages
        [HttpPost]
        public ActionResult SaveGalleryImages(int id)
        {
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];

                if (file != null && file.ContentLength > 0)
                {
                    var orginalDirectory = new DirectoryInfo(string.Format("{0}Content\\Images\\Uploads", Server.MapPath(@"\")));
                    string pathString1 = Path.Combine(orginalDirectory.ToString(), "Recipes\\" + id.ToString() + "\\Gallery");

                    var path = string.Format("{0}\\{1}", pathString1, file.FileName);

                    file.SaveAs(path);
                }
            }
            return View();
        }
    }
}