using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mrR_recipe_webapp.Models.DTO
{
    [Table("Dishes")]
    public class DishesDTO
    {
        [Key]
        public int Id_Dish { get; set; }
        [Required]
        public int Id_Category { get; set; }
        [Required]
        public int Id_Direction { get; set; }
        [Required]
        public int Id_Ingredient { get; set; }
        [Required]
        public int Id_Gallery { get; set; }
        [Required]
        public int Id_Author { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public int Servings { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
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
        public virtual UsersDTO User { get; set; }
    }
}