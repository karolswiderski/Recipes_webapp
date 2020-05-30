using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mrR_recipe_webapp.Controllers
{
    public class SearchBarController : Controller
    {
        // GET: SearchBar
        public ActionResult SearchBarPartial()
        {
            return View();
        }
    }
}