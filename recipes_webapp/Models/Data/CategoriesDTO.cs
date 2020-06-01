using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace recipes_webapp.Models.Data
{
    [Table("Categories")]
    public class CategoriesDTO
    {
        [Key]
        public int Id_Category { get; set; }
        public string Name { get; set; }
    }
}