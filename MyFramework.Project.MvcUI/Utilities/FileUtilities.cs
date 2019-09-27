using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFramework.Project.MvcUI.Utilities
{
    public class FileUtilities
    {
        
        public static void FileAdd(HttpPostedFileBase imgSource,string imageName,HttpServerUtilityBase server)
        {
            var folder = server.MapPath("~/CmsFiles");
            var path = Path.Combine(folder, imageName);
            imgSource.SaveAs(path);
        }

        public static void FileDelete(HttpServerUtilityBase server, string imageName)
        {
            var folder = server.MapPath("~/CmsFiles/"+imageName);
            System.IO.File.Delete(folder);
        }

        public static string EmptyFileUpdate(string baslik,string resimName, HttpServerUtilityBase server)
        {
            var refactorBaslik = NameHelper.Helper(baslik);
            var data = resimName.Split('.');
            var resultName = refactorBaslik + "." + data[1];

            var path = server.MapPath("~/CmsFiles");
            var result = Path.Combine(path, resimName);
            var resultNew = Path.Combine(path, resultName);

            var file = System.IO.Directory.GetFiles(path);
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i] == result)
                {
                    System.IO.File.Move(result, resultNew);
                }
            }

            return resultName;

        }
    }
}