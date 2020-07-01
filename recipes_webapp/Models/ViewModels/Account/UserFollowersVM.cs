using recipes_webapp.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace recipes_webapp.Models.ViewModels.Account
{
    public class UserFollowersVM
    {
        public UserFollowersVM() { }

        public UserFollowersVM(User_FollowersDTO row)
        {
            Id_User_Followers = row.Id_User_Followers;
            User_Id = row.User_Id;
            Follower_Id = row.Follower_Id;
            Date_Of_Started = row.Date_Of_Started;
            Its_Still = row.Its_Still;
        }

        [Key]
        public int Id_User_Followers { get; set; }
        public int User_Id { get; set; }
        public int Follower_Id { get; set; }
        public DateTime Date_Of_Started { get; set; }
        public bool Its_Still { get; set; }
    }
}