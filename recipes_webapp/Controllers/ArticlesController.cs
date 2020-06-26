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
        // GET: Articles/Index/filter
        public ActionResult Index(string filter)
        {
            List<ArticlesVM> articlesList = null;
            using (Db db = new Db())
            {
                if (filter == "all")
                {
                    articlesList = db.Articles.ToArray().Select(x => new ArticlesVM(x)).ToList();
                }
                else if (filter == "najlepsze")
                {
                    articlesList = db.Articles.ToArray().Select(x => new ArticlesVM(x)).ToList();
                    articlesList = articlesList.OrderByDescending(x => x.Rating).ToList();
                }
                else if (filter == "najnowsze")
                {
                    articlesList = db.Articles.ToArray().Select(x => new ArticlesVM(x)).ToList();
                    articlesList = articlesList.OrderByDescending(x => x.Date_Added).ToList();
                }
                else if (filter == "najstarsze")
                {
                    articlesList = db.Articles.ToArray().Select(x => new ArticlesVM(x)).ToList();
                    articlesList = articlesList.OrderBy(x => x.Rating).ToList();
                }
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
                articlesList = articlesList.OrderByDescending(x => x.Rating).Take(3).ToList();
            }

            return PartialView(articlesList);
        }

        // GET: Articles/Details
        [HttpGet]
        public ActionResult Details(int id)
        {
            ArticlesDTO articleDTO;
            ArticlesVM articleVM;

            using (Db db = new Db())
            {
                articleDTO = db.Articles.Find(id);
                articleVM = new ArticlesVM(articleDTO);
                //TempData["author_name"] = db.Users.Where(x => x.User_Id == articleVM.Id_Author).Select(x => x.Login);

                Random rand = new Random();
                int toSkip = rand.Next(1, db.Articles.Count());
                TempData["random_id"] = db.Articles.OrderBy(r => Guid.NewGuid()).Skip(toSkip).Select(x => x.Id_Article).Take(1).First();
            }

            return View(articleVM);
        }
    }
}