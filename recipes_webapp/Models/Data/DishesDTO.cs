using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace recipes_webapp.Models.Data
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

        [ForeignKey("Id_Category")]
        public virtual CategoriesDTO Categories { get; set; }

        [ForeignKey("Id_Direction")]
        public virtual DirectionsDTO Directions { get; set; }

        [ForeignKey("Id_Ingredient")]
        public virtual IngredientsDTO Ingredients { get; set; }

        [ForeignKey("Id_Gallery")]
        public virtual GalleryDTO Gallery { get; set; }

        [ForeignKey("Id_Author")]
        public virtual UsersDTO Users { get; set; }
    }
}