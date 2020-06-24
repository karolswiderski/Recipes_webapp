using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace recipes_webapp.Models.Data
{
    [Table("Articles")]
    public class ArticlesDTO
    {
        [Key]
        public int Id_Article { get; set; }
        public int Id_Author { get; set; }
        public DateTime Date_Added { get; set; }
        public string Img_Path { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Rating { get; set; }

        [ForeignKey("Id_Author")]
        public virtual UsersDTO Users { get; set; }
    }
}