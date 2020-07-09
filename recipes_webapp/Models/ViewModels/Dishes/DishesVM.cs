using recipes_webapp.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace recipes_webapp.Models.ViewModels.Dishes
{
    public class DishesVM
    {
        public DishesVM() { }

        public DishesVM(DishesDTO row)
        {
            Id_Dish = row.Id_Dish;
            Id_Category = row.Id_Category;
            Id_Direction = row.Id_Direction;
            Id_Ingredient = row.Id_Ingredient;
            Id_Author = row.Id_Author;
            Gallery_Path = row.Gallery_Path;
            Name = row.Name;
            Description = row.Description;
            Time = row.Time;
            Level = row.Level;
            Servings = row.Servings;
            Rating = row.Rating;
            Date_Added = row.Date_Added;
        }

        [Key]
        public int Id_Dish { get; set; }
        public int Id_Category { get; set; }
        public int Id_Direction { get; set; }
        public int Id_Ingredient { get; set; }
        public int Id_Author { get; set; }
        public string Gallery_Path { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public int Level { get; set; }
        public int Servings { get; set; }
        public int Rating { get; set; }
        public DateTime Date_Added { get; set; }

        public IEnumerable<string> MyGallery { get; set; }
        public IEnumerable<SelectListItem> CategoriesSelectList { get; set; }
        public int Directions { get; set; }
        public int Ingredients { get; set; }
        public int User { get; set; }
    }
}