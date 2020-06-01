using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace recipes_webapp.Controllers
{
    public class SearchBarController : Controller
    {
        public ActionResult SearchBarPartialLayout()
        {
            return PartialView();
        }
        
        public ActionResult SearchBarPartialPage()
        {
            return PartialView();
        }
    }
}