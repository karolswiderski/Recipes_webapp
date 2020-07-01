using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace recipes_webapp.Models.Data
{
    [Table("Recipe_Followers")]
    public class Recipe_FollowersDTO
    {
        [Key]
        public int Id_Recipe_Followers { get; set; }
        public int Recipe_Id { get; set; }
        public int Follower_Id { get; set; }
        public DateTime Date_Of_Started { get; set; }
        public byte Its_Still { get; set; }
    }
}