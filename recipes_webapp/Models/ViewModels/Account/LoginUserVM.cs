using System.ComponentModel.DataAnnotations;

namespace recipes_webapp.Models.ViewModels.Account
{
    public class LoginUserVM
    {
        [Key]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Remember_Me { get; set; }
    }
}