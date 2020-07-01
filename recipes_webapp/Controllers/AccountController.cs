using recipes_webapp.Models.Data;
using recipes_webapp.Models.ViewModels.Account;
using recipes_webapp.Models.ViewModels.Dishes;
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
                TempData["Warning"] = "Autoryzacja nie powiodła się. Spróbuj ponownie.";
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
                TempData["Warning"] = "Autoryzacja nie powiodła się. Spróbuj ponownie.";
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
            if (model.User_Name == null || model.Login == null || model.Password == null || model.Repeat_Password == null)
            {
                TempData["Warning"] = "Nie wszystkie pola zostały uzupełnione. Uzupełnij braki i spróbuj ponownie.";
                return View(model);
            }

            if (model.Password != model.Repeat_Password)
            {
                TempData["Warning"] = "Podane hasła różnią się od siebie. Wpisz identyczne hasła i spróbuj ponownie.";
                return View(model);
            }

            if (model.Password.Length < 8 || model.Repeat_Password.Length < 8)
            {
                TempData["Warning"] = "Hasło musi składać się z conajmniej 8 znaków. Wpisz dłuższe hasło i spróbuj ponownie.";
                return View(model);
            }

            using (Db db = new Db())
            {
                UsersDTO sameLogin = db.Users.FirstOrDefault(x => x.Login == model.Login);
                if (sameLogin != null)
                {
                    TempData["Warning"] = "Wybrany login jest już zajęty. Wybierz inny login i spróbuj ponownie.";
                    return View(model);
                }


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

        // GET: Account/My
        [HttpGet]
        public ActionResult My()
        {
            string userName = User.Identity.Name;
            if (string.IsNullOrEmpty(userName)) return Redirect("~/Recipes/Index");
            UsersVM myAccountModel;

            using (Db db = new Db())
            {
                UsersDTO myAccount = db.Users.FirstOrDefault(x => x.Login == userName);
                myAccountModel = new UsersVM(myAccount);
            }

            return View(myAccountModel);
        }

        [HttpGet]
        public ActionResult MyRecipes() 
        {
            List<DishesVM> myRecipesList;

            using (Db db = new Db())
            {
                UsersDTO myAccount = db.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
                myRecipesList = db.Dishes.ToArray().Where(x => x.Id_Author == myAccount.Id_User).Select(x => new DishesVM(x)).ToList();    
            }

            return PartialView(myRecipesList);
        }
         
        [HttpGet]
        public ActionResult MyFollowingUsers(int id)
        {
            List<int> userFollowersVM = new List<int>();
            List<UsersVM> myFollowingList = new List<UsersVM>();

            using (Db db = new Db())
            {
                userFollowersVM = db.User_Followers.ToArray().Where(x => x.Follower_Id == id && x.Its_Still == true).Select(x => x.User_Id).ToList();

                foreach (var item in userFollowersVM)
                {
                    UsersDTO myFollowing = db.Users.FirstOrDefault(x => x.Id_User == item);

                    myFollowingList.Add(new UsersVM(myFollowing));
                }
            }

            return PartialView(myFollowingList);
        }

        [HttpGet]
        public ActionResult MyFollowingRecipes(int id)
        {
            List<int> recipeFollowersVM = new List<int>();
            List<DishesVM> myFollowingList = new List<DishesVM>();

            using (Db db = new Db())
            {
                recipeFollowersVM = db.Recipe_Followers.ToArray().Where(x => x.Follower_Id == id && x.Its_Still == true).Select(x => x.Recipe_Id).ToList();

                foreach (var item in recipeFollowersVM)
                {
                    DishesDTO myFollowing = db.Dishes.FirstOrDefault(x => x.Id_Dish == item);

                    myFollowingList.Add(new DishesVM(myFollowing));
                }
            }

            return PartialView(myFollowingList);
        }
    }
}