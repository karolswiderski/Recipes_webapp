using recipes_webapp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace recipes_webapp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest()
        {
            if (User == null) return;
            string userLogin = Context.User.Identity.Name;

            string[] roles = null;
            using (Db db = new Db())
            {
                UsersDTO dto = db.Users.FirstOrDefault(x => x.Login == userLogin);
                roles = db.Users.Where(x => x.Id_User == dto.Id_User).Select(x => x.Role).ToArray();
            }

            IIdentity userIdentity = new GenericIdentity(userLogin);
            IPrincipal newUserObj = new GenericPrincipal(userIdentity, roles);

            Context.User = newUserObj;
        }
    }
}
