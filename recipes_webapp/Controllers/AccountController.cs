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
            return Redirect("~/Account/My?mode=1");
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
        public ActionResult My(int mode)
        {
            TempData["setMode"] = mode;
            string userName = User.Identity.Name;
            if (string.IsNullOrEmpty(userName)) return Redirect("~/Recipes/Index");
            UsersVM myAccountModel;

            using (Db db = new Db())
            {
                UsersDTO myAccount = db.Users.FirstOrDefault(x => x.Login == userName);
                myAccountModel = new UsersVM(myAccount);
                TempData["myRecipesCount"] = db.Dishes.Where(x => x.Id_Author == myAccount.Id_User).Count();
                TempData["myFollowingRecipesCount"] = db.Recipe_Followers.Where(x => x.Follower_Id == myAccount.Id_User).Count();
                TempData["myFollowingUsersCount"] = db.User_Followers.Where(x => x.Follower_Id == myAccount.Id_User).Count();
            }

            return View(myAccountModel);
        }

        [HttpGet]
        public ActionResult MyRecipes(int userId, string orderBy)
        {
            List<DishesVM> DishesList = new List<DishesVM>();

            using (Db db = new Db())
            {
                if (orderBy == "newest") DishesList = db.Dishes.Where(x => x.Id_Author == userId).ToArray().Select(x => new DishesVM(x)).OrderBy(x => x.Date_Added).ToList();
                else if (orderBy == "oldest") DishesList = db.Dishes.Where(x => x.Id_Author == userId).ToArray().Select(x => new DishesVM(x)).OrderByDescending(x => x.Date_Added).ToList();
                else if (orderBy == "mostPopular") DishesList = db.Dishes.Where(x => x.Id_Author == userId).ToArray().Select(x => new DishesVM(x)).OrderBy(x => x.Rating).ToList();
                TempData["userId"] = userId;
            }

            return PartialView(DishesList);
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
        public ActionResult MyFollowingRecipes(int userId, string orderBy)
        {
            List<DishesVM> DishesList = new List<DishesVM>();
            List<int> followingList = new List<int>();

            using (Db db = new Db())
            {
                followingList = db.Recipe_Followers.Where(x => x.Follower_Id == userId).ToArray().Select(x => x.Recipe_Id).ToList();
                foreach (var item in followingList)
                {
                    DishesDTO dish = db.Dishes.Find(item);
                    DishesList.Add(new DishesVM(dish));
                }
                
                if (orderBy == "newest") DishesList = DishesList.OrderBy(x => x.Date_Added).ToList();
                else if (orderBy == "mostPopular") DishesList.OrderBy(x => x.Rating).ToList();
            }

            return PartialView(DishesList);
        }

        // GET: Account/ChangeSignature
        [HttpGet]
        public ActionResult ChangeSignature(int id)
        {
            UsersVM myAccountModel;

            using (Db db = new Db())
            {
                UsersDTO myAccount = db.Users.FirstOrDefault(x => x.Id_User == id);
                myAccountModel = new UsersVM(myAccount);
            }

            return PartialView(myAccountModel);
        }

        // POST: Account/ChangeSignature
        [HttpPost]
        public ActionResult ChangeSignature(UsersVM model)
        {
            if (model.User_Name.Length < 4)
            {
                TempData["UserName_Warning"] = "Nazwa użytkownika musi składać się z conajmniej 4 znaków. Wpisz dłuższą nazwę i spróbuj ponownie.";
                return RedirectToAction("My", new { mode = 4 });
            }
            using (Db db = new Db())
            {
                UsersDTO dto = db.Users.Find(model.Id_User);
                dto.User_Name = model.User_Name;

                db.SaveChanges();
            }

            TempData["UserName_Warning"] = "";
            TempData["UserName_Success"] = "Edycja podpisu zakończona sukcesem.";
            return RedirectToAction("My", new { mode = 1 });
        }

        // GET: Account/ChangePassword
        [HttpGet]
        public ActionResult ChangePassword(int id)
        {
            UsersVM myAccountModel;

            using (Db db = new Db())
            {
                UsersDTO myAccount = db.Users.FirstOrDefault(x => x.Id_User == id);
                myAccountModel = new UsersVM(myAccount);
            }

            return PartialView(myAccountModel);
        }

        // POST: Account/ChangePassword
        [HttpPost]
        public ActionResult ChangePassword(UsersVM model)
        {
            if (model.Password == null || model.Repeat_Password == null)
            {
                TempData["Password_Warning"] = "Nie wszystkie pola zostały uzupełnione. Uzupełnij braki i spróbuj ponownie.";
                return RedirectToAction("My", new { mode = 5 });
            }
            if (model.Repeat_Password.Length < 8)
            {
                TempData["Password_Warning"] = "Nowe hasło musi składać się z conajmniej 8 znaków. Wpisz dłuższe hasło i spróbuj ponownie.";
                return RedirectToAction("My", new { mode = 5 });
            }
            using (Db db = new Db())
            {
                UsersDTO dto = db.Users.Find(model.Id_User);

                if (model.Password == dto.Password)
                {
                    if (model.Password == model.Repeat_Password)
                    {
                        TempData["Password_Warning"] = "Podane hasła nie różnią się od siebie. Wybierz inne hasło i spróbuj ponownie.";
                        return RedirectToAction("My", new { mode = 5 });
                    }
                    dto.Password = model.Repeat_Password;
                    dto.Repeat_Password = model.Repeat_Password;

                    db.SaveChanges();
                }
                else
                {
                    TempData["Password_Warning"] = "Potwierdzenie Twojego hasła nie powiodło się. Spróbuj ponownie.";
                    return RedirectToAction("My", new { mode = 5 });
                }
            }

            TempData["Password_Warning"] = "";
            TempData["Password_Success"] = "Edycja hasła zakończona sukcesem.";
            return RedirectToAction("My", new { mode = 5 });
        }

        [HttpGet]
        public ActionResult SingleRecipe(int id) {
            DishesVM recipeVM;

            using (Db db = new Db())
            {
                DishesDTO recipeDTO = db.Dishes.Find(id);
                recipeVM = new DishesVM(recipeDTO);
            }

            return PartialView(recipeVM);
        }
    }
}