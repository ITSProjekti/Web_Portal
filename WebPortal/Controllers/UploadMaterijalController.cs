using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPortal.Models;
using System.Data.Entity;

namespace WebPortal.Content.uploads
{
    public class UploadMaterijalController : Controller
    {
        private ApplicationDbContext _context;

        public UploadMaterijalController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

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
                    MaterijalModel materijal = new MaterijalModel();
                    string nazivFajla = Path.GetFileName(file.FileName);
                    string putanjaFajla = Path.Combine(Server.MapPath("~/Content/uploads"), nazivFajla);
                    file.SaveAs(putanjaFajla);
                    materijal.materijalNaziv = nazivFajla;
                    materijal.materijalTip = Path.GetExtension(putanjaFajla);
                    materijal.materijalUrl = putanjaFajla;
                    _context.Materijal.Add(materijal);
                    _context.SaveChanges();
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