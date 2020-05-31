using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace recipes_webapp.Models.DTO
{
    [Table("Dishes")]
    public class DishesDTO
    {
        [Key]
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
    }
}