using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace recipes_webapp.Models.Data
{
    [Table("Users")]
    public class UsersDTO
    {
        [Key]
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Date_Of_Joing { get; set; }
        public int Recommendations { get; set; }
        public string Role { get; set; }
    }
}