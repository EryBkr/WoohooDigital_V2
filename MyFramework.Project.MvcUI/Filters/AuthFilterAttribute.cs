using MyFramework.Project.MvcUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFramework.Project.MvcUI.Filters
{
    public class AuthFilterAttribute : FilterAttribute, IAuthorizationFilter
    {
        
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}