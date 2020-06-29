using recipes_webapp.Models.Data;
using recipes_webapp.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace recipes_webapp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return Redirect("~/Account/Login");
        }

        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            string userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName)) return Redirect("~/Recipes/Index");

            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public ActionResult Login(LoginUserVM model)
        {
            if (model.Login == null || model.Password == null)
            {
                TempData["Warning"] = "upss.. Chyba o czymś zapomniałeś.";
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                TempData["Warning"] = "upss.. Coś poszło nie tak.";
                return View(model);
            }

            bool isValid = false;
            using (Db db = new Db())
            {
                if (db.Users.Any(x => x.Login.Equals(model.Login) && x.Password.Equals(model.Password)))
                {
                    isValid = true;
                }
            }

            if (!isValid)
            {
                TempData["Warning"] = "Nazwa użytkownika lub hasło jest błędne. ";
                return View(model);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.Login, model.Remember_Me);
                return RedirectToAction(FormsAuthentication.GetRedirectUrl(model.Login, model.Remember_Me));
            }
        }

        // GET: Account/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        // GET: Account/CreateNew
        [HttpGet]
        public ActionResult CreateNew()
        {
            string userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName)) return Redirect("~/Recipes/Index");

            return View();
        }
    }
}