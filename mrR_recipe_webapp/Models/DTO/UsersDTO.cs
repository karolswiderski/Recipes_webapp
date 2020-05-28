using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mrR_recipe_webapp.Models.DTO
{
    [Table("Users")]
    public class UsersDTO
    {
        [Key]
        public int User_Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}