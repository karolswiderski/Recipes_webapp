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

        // GET: Recipes/Details/id
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
        public ActionResult PhotoSlider(int id)
        {
            DishesVM dish = new DishesVM();

            using (Db db = new Db())
            {
                DishesDTO dto = db.Dishes.Find(id);
                dish = new DishesVM(dto);
                dish.MyGallery = Directory.EnumerateFiles(Server.MapPath("~/Content/Images/Uploads/Recipes/" + id + "/Gallery")).Select(fn => Path.GetFileName(fn));

            }

            return PartialView(dish);
            
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

        // GET: Recipes/AddNew
        [HttpGet]
        public ActionResult AddNew()
        {
            List<Level> level = new List<Level>
            {
                new Level() { Level_Id = 1, Level_Name = "Łatwy" },
                new Level() { Level_Id = 2, Level_Name = "Średni" },
                new Level() { Level_Id = 3, Level_Name = "Trudny" }
            };

            CategoriesDTO catDTO = new CategoriesDTO();
            DirectionsDTO dirDTO = new DirectionsDTO();
            DishesDTO disDTO = new DishesDTO();
            IngredientsDTO ingDTO = new IngredientsDTO();
            AddNewRecipeVM model = new AddNewRecipeVM(catDTO, dirDTO, disDTO, ingDTO);

            using (Db db = new Db())
            {
                model.Dishes.CategoriesSelectList = new SelectList(db.Categories.ToList(), "Id_Category", "Name");
                model.LevelList = new SelectList(level, "Level_Id", "Level_Name");
            }
            return View(model);
        }

        // POST: Recipes/AddNew
        [HttpPost]
        public ActionResult AddNew(AddNewRecipeVM model, HttpPostedFileBase file)
        {
            #region Preparation-List-If-Will-Be-Errors
            List<Level> level = new List<Level>();
            level.Add(new Level() { Level_Id = 1, Level_Name = "Łatwy" });
            level.Add(new Level() { Level_Id = 2, Level_Name = "Średni" });
            level.Add(new Level() { Level_Id = 3, Level_Name = "Trudny" });
            using (Db db = new Db())
            {
                model.Dishes.CategoriesSelectList = new SelectList(db.Categories.ToList(), "Id_Category", "Name");
                model.LevelList = new SelectList(level, "Level_Id", "Level_Name");
            }
            #endregion

            //Exception Handling:
            #region Basic-information
            if (model.Dishes.Id_Category == 0) { TempData["WarningSection1"] = "Kategoria pozostała pusta. Uzupełnij braki i spróbuj ponownie."; return View(model); }
            if (model.Dishes.Name == null) { TempData["WarningSection1"] = "Nazwa potrawy pozostała pusta. Uzupełnij braki i spróbuj ponownie."; return View(model); }
            if (model.Dishes.Description == null) { TempData["WarningSection1"] = "Opis przepisu i potrawy pozostał pusty. Uzupełnij braki i spróbuj ponownie."; return View(model); }
            if (model.Dishes.Servings == 0) { TempData["WarningSection1"] = "Ilość porcji pozostała pusta. Uzupełnij braki i spróbuj ponownie."; return View(model); }
            if (model.Dishes.Time == null || model.Dishes.Time == "0") { TempData["WarningSection1"] = "Czas przygotowania pozostał pusty. Uzupełnij braki i spróbuj ponownie."; return View(model); }
            if (model.Dishes.Level == 0) { TempData["WarningSection1"] = "Poziom trudności pozostał pusty. Uzupełnij braki i spróbuj ponownie."; return View(model); }

            if (model.Dishes.Name.Length < 3) { TempData["WarningSection1"] = "Nazwa potrawy powinna składać się z co najmniej 3 znaków. Popraw błędy i spróbuj ponownie."; return View(model); }
            if (model.Dishes.Description.Length < 15) { TempData["WarningSection1"] = "Opis potrawy powinna składać się z co najmniej 15 znaków. Popraw błędy i spróbuj ponownie."; return View(model); }
            #endregion

            #region Ingredients-List
            if (model.Ingredients.Ingredient_1 == null) { TempData["WarningSection2"] = "Musisz dodać co najmniej jeden składnik. Uzupełnij braki i spróbuj ponownie."; return View(model); }
            #endregion

            #region Direction-List
            if (model.Directions.Step_1_Content == null) { TempData["WarningSection3"] = "Musisz dodać co najmniej jeden krok przygotowania. Uzupełnij braki i spróbuj ponownie."; return View(model); }
            #endregion

            //Post Method:

            int id;
            using (Db db = new Db())
            {
                #region Add-Ingredients-To-Db
                IngredientsDTO ingredients = new IngredientsDTO();
                ingredients.Ingredient_1 = model.Ingredients.Ingredient_1;

                if (model.Ingredients.Ingredient_2 != null) ingredients.Ingredient_2 = model.Ingredients.Ingredient_2;
                else ingredients.Ingredient_2 = "";
                if (model.Ingredients.Ingredient_3 != null) ingredients.Ingredient_3 = model.Ingredients.Ingredient_3;
                else ingredients.Ingredient_3 = "";
                if (model.Ingredients.Ingredient_4 != null) ingredients.Ingredient_4 = model.Ingredients.Ingredient_4;
                else ingredients.Ingredient_4 = "";
                if (model.Ingredients.Ingredient_5 != null) ingredients.Ingredient_5 = model.Ingredients.Ingredient_5;
                else ingredients.Ingredient_5 = "";
                if (model.Ingredients.Ingredient_6 != null) ingredients.Ingredient_6 = model.Ingredients.Ingredient_6;
                else ingredients.Ingredient_6 = "";
                if (model.Ingredients.Ingredient_7 != null) ingredients.Ingredient_7 = model.Ingredients.Ingredient_7;
                else ingredients.Ingredient_7 = "";
                if (model.Ingredients.Ingredient_8 != null) ingredients.Ingredient_8 = model.Ingredients.Ingredient_8;
                else ingredients.Ingredient_8 = "";
                if (model.Ingredients.Ingredient_9 != null) ingredients.Ingredient_9 = model.Ingredients.Ingredient_9;
                else ingredients.Ingredient_9 = "";
                if (model.Ingredients.Ingredient_10 != null) ingredients.Ingredient_10 = model.Ingredients.Ingredient_10;
                else ingredients.Ingredient_10 = "";
                if (model.Ingredients.Ingredient_11 != null) ingredients.Ingredient_11 = model.Ingredients.Ingredient_11;
                else ingredients.Ingredient_11 = "";
                if (model.Ingredients.Ingredient_12 != null) ingredients.Ingredient_12 = model.Ingredients.Ingredient_12;
                else ingredients.Ingredient_12 = "";
                if (model.Ingredients.Ingredient_13 != null) ingredients.Ingredient_13 = model.Ingredients.Ingredient_13;
                else ingredients.Ingredient_13 = "";
                if (model.Ingredients.Ingredient_14 != null) ingredients.Ingredient_14 = model.Ingredients.Ingredient_14;
                else ingredients.Ingredient_14 = "";
                if (model.Ingredients.Ingredient_15 != null) ingredients.Ingredient_15 = model.Ingredients.Ingredient_15;
                else ingredients.Ingredient_15 = "";

                db.Ingredients.Add(ingredients);
                #endregion

                #region Add-Directions-To-Db
                DirectionsDTO directions = new DirectionsDTO();
                directions.Step_1_Content = model.Directions.Step_1_Content;

                if (model.Directions.Step_2_Content != null) directions.Step_2_Content = model.Directions.Step_2_Content;
                else directions.Step_2_Content = "";
                if (model.Directions.Step_3_Content != null) directions.Step_3_Content = model.Directions.Step_3_Content;
                else directions.Step_3_Content = "";
                if (model.Directions.Step_4_Content != null) directions.Step_4_Content = model.Directions.Step_4_Content;
                else directions.Step_4_Content = "";
                if (model.Directions.Step_5_Content != null) directions.Step_5_Content = model.Directions.Step_5_Content;
                else directions.Step_5_Content = "";
                if (model.Directions.Step_6_Content != null) directions.Step_6_Content = model.Directions.Step_6_Content;
                else directions.Step_6_Content = "";
                if (model.Directions.Step_7_Content != null) directions.Step_7_Content = model.Directions.Step_7_Content;
                else directions.Step_7_Content = "";
                if (model.Directions.Step_8_Content != null) directions.Step_8_Content = model.Directions.Step_8_Content;
                else directions.Step_8_Content = "";
                if (model.Directions.Step_9_Content != null) directions.Step_9_Content = model.Directions.Step_9_Content;
                else directions.Step_9_Content = "";
                if (model.Directions.Step_10_Content != null) directions.Step_10_Content = model.Directions.Step_10_Content;
                else directions.Step_10_Content = "";

                db.Directions.Add(directions);
                #endregion

                db.SaveChanges();

                string userName = User.Identity.Name;
                UsersDTO user = db.Users.FirstOrDefault(x => x.Login == userName);

                DishesDTO dish = new DishesDTO
                {
                    Id_Author = user.Id_User,
                    Id_Category = model.Dishes.Id_Category,
                    Id_Direction = directions.Id_Direction,
                    Id_Ingredient = ingredients.Id_Ingredient,
                    Name = model.Dishes.Name,
                    Description = model.Dishes.Description,
                    Servings = model.Dishes.Servings,
                    Time = model.Dishes.Time,
                    Level = model.Dishes.Level,
                    Date_Added = Convert.ToDateTime(DateTime.Today.ToString("dd-MM-yyyy"))
                };

                db.Dishes.Add(dish);
                db.SaveChanges();
                id = dish.Id_Dish;
            }

            #region Add-Gallery-Path
            var originalDirectory = new DirectoryInfo(string.Format("{0}Content\\Images\\Uploads", Server.MapPath(@"\")));
            var pathString1 = Path.Combine(originalDirectory.ToString(), "Recipes");
            var pathString2 = Path.Combine(originalDirectory.ToString(), "Recipes\\" + id.ToString());
            var pathString4 = Path.Combine(originalDirectory.ToString(), "Recipes\\" + id.ToString() + "\\Thumbs");
            var pathString3 = Path.Combine(originalDirectory.ToString(), "Recipes\\" + id.ToString() + "\\Gallery");

            if (!Directory.Exists(pathString1)) Directory.CreateDirectory(pathString1);
            if (!Directory.Exists(pathString2)) Directory.CreateDirectory(pathString2);
            if (!Directory.Exists(pathString3)) Directory.CreateDirectory(pathString3);
            if (!Directory.Exists(pathString4)) Directory.CreateDirectory(pathString4);

            using (Db db = new Db())
            {
                DishesDTO dish = new DishesDTO();
                dish = db.Dishes.Find(id);
                dish.Gallery_Path = pathString4;
                db.SaveChanges();
            }
            #endregion

            return RedirectToAction("AddPhotos", new { id });
        }

        // GET: Recipes/AddNew/AddPhotos
        [HttpGet]
        public ActionResult AddPhotos(int id)
        {
            DishesVM model;
            TempData["RecipeId"] = id;
                
            using (Db db = new Db())
            {
                DishesDTO dish = db.Dishes.Find(id);
                model = new DishesVM(dish);
                TempData["DishName"] = model.Name;
                model.MyGallery = Directory.EnumerateFiles(Server.MapPath("~/Content/Images/Uploads/Recipes/" + id + "/Thumbs")).Select(fn => Path.GetFileName(fn));
            }
            return View(model);
        }

        // POST: Recipes/SaveGalleryImages
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
                    string pathString2 = Path.Combine(orginalDirectory.ToString(), "Recipes\\" + id.ToString() + "\\Thumbs");

                    var path = string.Format("{0}\\{1}", pathString1, file.FileName);
                    var path2 = string.Format("{0}\\{1}", pathString2, file.FileName);

                    file.SaveAs(path);
                    WebImage img;
                    try
                    {
                        img = new WebImage(file.InputStream);
                        img.Resize(200, 200);
                        img.Save(path2);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return RedirectToAction("/Recipes/Index");
                    }
                }
            }
            return View();
        }
    }
}