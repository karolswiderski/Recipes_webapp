using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace recipes_webapp.Models.Data
{
    [Table("User_Followers")]
    public class User_FollowersDTO
    {
        [Key]
        public int Id_User_Followers { get; set; }
        public int User_Id { get; set; }
        public int Follower_Id { get; set; }
        public DateTime Date_Of_Started { get; set; }
        public byte Its_Still { get; set; }
    }
}