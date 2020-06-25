using recipes_webapp.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace recipes_webapp.Models.ViewModels.Articles
{
    public class ArticlesVM
    {
        public ArticlesVM() { }

        public ArticlesVM(ArticlesDTO row) {
            Id_Article = row.Id_Article;
            Id_Author = row.Id_Author;
            Date_Added = row.Date_Added;
            Img_Path = row.Img_Path;
            Title = row.Title;
            Content = row.Content;
            Rating = row.Rating;
        }

        [Key]
        public int Id_Article { get; set; }
        public int Id_Author { get; set; }
        public DateTime Date_Added { get; set; }
        public string Img_Path { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}