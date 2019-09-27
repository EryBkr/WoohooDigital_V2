using MyFramework.Project.Business.Abstract;
using MyFramework.Project.Entities.Concrete;
using MyFramework.Project.MvcUI.Filters;
using MyFramework.Project.MvcUI.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFramework.Project.MvcUI.Controllers
{
    [AuthFilter]
    public class AdminController : Controller
    {
        IHaberManager _haberManager;
        public AdminController(IHaberManager haberManager)
        {
            _haberManager = haberManager;
        }

        public ActionResult Index(int page = 1)
        {
            double count = _haberManager.GetAll().Count();
         
                TempData["sayfaSayisi"] = (int)Math.Ceiling(count / 2);
            
            
            var haberler = _haberManager.GetAll().OrderBy(i => i.SiraNo).Skip((page - 1) * 2).Take(2).ToList();
            return View(haberler);
        }

        [HttpGet]
        public ActionResult HaberAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HaberAdd(Haber haber, HttpPostedFileBase file)
        {
            var imageName = NameHelper.Helper(haber.Baslik);
            var extension = Path.GetExtension(file.FileName);
            haber.Resim = imageName+extension;

            if (ModelState.IsValid)
            {
                if (file != null)
                {

                    FileUtilities.FileAdd(file,haber.Resim, Server);
                }
                _haberManager.Add(haber);
                return RedirectToAction("Index", "Admin");
            }
            return View();

        }


        [HttpGet]
        public ActionResult HaberUpdate(int id)
        {
            var haber = _haberManager.Get(id);
            return View(haber);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HaberUpdate(Haber haber, HttpPostedFileBase file)
        {
            string imageName; 
            string extension;
           

            if (ModelState.IsValid)
            {
                if (file==null)
                {
                    haber.Resim = FileUtilities.EmptyFileUpdate(haber.Baslik, haber.Resim, Server);
                }

                if (file != null)
                {
                    FileUtilities.FileDelete(Server, haber.Resim);
                    imageName = NameHelper.Helper(haber.Baslik);
                    extension = Path.GetExtension(file.FileName);
                    haber.Resim = imageName + extension;
                    FileUtilities.FileAdd(file, haber.Resim, Server);
                }

                _haberManager.Update(haber);
                return RedirectToAction("Index", "Admin");
            }
            return View();

        }


        public ActionResult HaberDelete(int id)
        {
            var haber = _haberManager.Get(id);
            FileUtilities.FileDelete(Server, haber.Resim);
            _haberManager.Delete(haber);
            return RedirectToAction("Index", "Admin");
        }
    }
}