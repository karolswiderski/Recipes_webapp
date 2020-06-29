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
            if (model.Login == null || model.Password == null || !ModelState.IsValid)
            {
                TempData["Warning"] = "Zweryfikuj podane dane i spróbuj ponownie";
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


        // POST: Account/CreateNew
        [HttpPost]
        public ActionResult CreateNew(UsersVM model)
        {

            using (Db db = new Db())
            {
                UsersDTO userDTO = new UsersDTO();
                userDTO.User_Name = model.User_Name;
                userDTO.Login = model.Login;
                userDTO.Password = model.Password;
                userDTO.Repeat_Password = model.Repeat_Password;
                userDTO.Recommendations = 0;
                userDTO.Role = "user";
                userDTO.Date_Of_Joing = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));

                db.Users.Add(userDTO);
                db.SaveChanges();
            }

            return RedirectToAction("Login");
        }
    }
}