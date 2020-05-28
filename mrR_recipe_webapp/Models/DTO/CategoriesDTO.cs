using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mrR_recipe_webapp.Models.DTO
{
    [Table("Categories")]
    public class CategoriesDTO
    {
        [Key]
        public int Id_Category { get; set; }
        public string Name { get; set; }
    }
}