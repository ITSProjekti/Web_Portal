using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPortal.Content.uploads
{
    public class UploadMaterijalController : Controller
    {
        // GET: UploadMaterijal
        //public ActionResult UploadMaterijalView()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult UploadMaterijal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadMaterijal(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath ("~/Content/uploads"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "Uspešno ste postavili materijal!";
                return View(); 
            }
            catch
            {
                ViewBag.Message = "Postavljanje materijala nije uspelo!";
                return View();
            }
        }
    }
}