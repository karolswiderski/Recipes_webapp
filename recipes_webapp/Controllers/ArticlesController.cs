using recipes_webapp.Models.Data;
using recipes_webapp.Models.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace recipes_webapp.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {
            List <ArticlesVM> articlesList;

            using (Db db = new Db())
            {
                articlesList = db.Articles.ToArray().Select(x => new ArticlesVM(x)).ToList();
            }

            return View(articlesList);
        }

        [HttpGet]
        public ActionResult BestArticle()
        {
            List<ArticlesVM> articlesList;

            using (Db db = new Db())
            {
                articlesList = db.Articles.ToArray().Select(x => new ArticlesVM(x)).ToList();
            }

            return PartialView(articlesList);
        }
    }
}