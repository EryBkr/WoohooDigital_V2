using MyFramework.Project.Business.Abstract;
using MyFramework.Project.MvcUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFramework.Project.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        IHaberManager _haberManager;

        public HomeController(IHaberManager haberManager)
        {
            _haberManager = haberManager;
        }


        [Route("")]
        public ActionResult Index(int page = 1)
        {
            var haberler = _haberManager.GetAll().Where(i=>i.Aktiflik==true).OrderBy(i => i.SiraNo).Skip((page - 1) * 2).Take(2).ToList();
            double count = _haberManager.GetAll().Where(i => i.Aktiflik == true).ToList().Count();
            TempData["sayfaSayisi"] = (int)Math.Ceiling(count / 2);
            return View(haberler);
        }

        [Route("haber/{baslik}")]
        public ActionResult HaberDetay(int id)
        {
            var haber = _haberManager.Get(id);

            return View(haber);
        }
    }
}