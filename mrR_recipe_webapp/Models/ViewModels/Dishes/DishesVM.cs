using mrR_recipe_webapp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace mrR_recipe_webapp.Models.ViewModels.Dishes
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
            Id_Gallery = row.Id_Gallery;
            Id_Author = row.Id_Author;
            Name = row.Name;
            Description = row.Description;
            Time = row.Time;
            Level = row.Level;
            Servings = row.Servings;
            Rating = row.Rating;
            Date_Added = row.Date_Added;

        }

        public int Id_Dish { get; set; }
        public int Id_Category { get; set; }
        public int Id_Direction { get; set; }
        public int Id_Ingredient { get; set; }
        public int Id_Gallery { get; set; }
        public int Id_Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public int Level { get; set; }
        public int Servings { get; set; }
        public int Rating { get; set; }
        public DateTime Date_Added { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}