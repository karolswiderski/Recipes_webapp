using recipes_webapp.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace recipes_webapp.Models.ViewModels.Account
{
    public class RecipeFollowersVM
    {
        public RecipeFollowersVM() { }

        public RecipeFollowersVM(Recipe_FollowersDTO row)
        {
            Id_Recipe_Followers = row.Id_Recipe_Followers;
            Recipe_Id = row.Recipe_Id;
            Follower_Id = row.Follower_Id;
            Date_Of_Started = row.Date_Of_Started;
            Its_Still = row.Its_Still;
        }

        [Key]
        public int Id_Recipe_Followers { get; set; }
        public int Recipe_Id { get; set; }
        public int Follower_Id { get; set; }
        public DateTime Date_Of_Started { get; set; }
        public byte Its_Still { get; set; }
    }
}