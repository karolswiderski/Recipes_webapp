using recipes_webapp.Models.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace recipes_webapp.Models.ViewModels.Account
{
    public class UsersVM
    {
        public UsersVM() { }

        public UsersVM(UsersDTO row)
        {
            Id_User = row.Id_User;
            User_Name = row.User_Name;
            Login = row.Login;
            Password = row.Password;
            Repeat_Password = row.Repeat_Password;
            Date_Of_Joing = row.Date_Of_Joing;
            Recommendations = row.Recommendations;
            Role = row.Role;
        }

        [Key]
        public int Id_User { get; set; }
        public string User_Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Repeat_Password { get; set; }
        public DateTime Date_Of_Joing { get; set; }
        public int Recommendations { get; set; }
        public string Role { get; set; }
    }
}