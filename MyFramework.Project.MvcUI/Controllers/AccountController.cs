using MyFramework.Core.CrossCuttingConcerns.Security.Web;
using MyFramework.Project.Business.Abstract;
using MyFramework.Project.Entities.Concrete;
using MyFramework.Project.MvcUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyFramework.Project.MvcUI.Controllers
{
   
    public class AccountController : Controller
    {
        IUserManager _userService;
        public AccountController(IUserManager userManager)
        {
            _userService = userManager;
        }

        [HttpGet]
        public ActionResult Login()
        {    
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string name, string pass)
        {
            var user = _userService.GetUserNameAndPassword(name, pass);
            if (user != null)
            {
                AuthHelper.CreateAuthCookie(new Guid(), user.Name, "black@gmail.com", DateTime.Now.AddMinutes(15), user.myRole, false);
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
    
        public ActionResult Register()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            _userService.Add(user);

            return RedirectToAction("Index","Product");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}