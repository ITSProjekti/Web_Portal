

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPortal.Models;
using WebPortal.ViewModels;
using System.Data.Entity;

namespace WebPortal.Content.uploads
{
    public class UploadMaterijalController : Controller
    {


        private IMaterijalContext context;

        public UploadMaterijalController()
        {
            context = new MaterijalContext();
        }

        public UploadMaterijalController(IMaterijalContext Context)
        {
            context = Context;
        }

<<<<<<< HEAD
        //[HttpGet]
        //public ActionResult Download(int id)
        //{
        //    var file = _context.Materijal.SingleOrDefault(c => c.materijalId == id);
        //    var cd = new System.Net.Mime.ContentDisposition
        //    {
        //        FileName = file.materijalNaziv,
        //        Inline = false,

        //    };

        //    Response.AppendHeader("Content-Disposition", cd.ToString());
        //    return File(file.materijalNaziv, file.materijalTip);
        //}

        //[HttpGet]
        //public ActionResult MaterijaliPrikaz()
        //{
        //    var materijali = _context.Materijal.ToList();
        //    MaterijalViewModel ViewModel = new MaterijalViewModel
        //    {
        //        materijaliLista = materijali
        //    };

        //    return View(ViewModel);
        //}
=======


        [HttpGet]
        public ActionResult MaterijaliPrikaz(int number = 0)
        {
            List<MaterijalModel> materijali;
            materijali = context.materijali.ToList();
            if (number == 0)
            {
                materijali = context.materijali.ToList();
            }
            else
            {
                materijali = (from p in context.materijali
                              select p).Take(number).ToList();
            }

            return View("MaterijaliPrikaz", materijali);

        }
>>>>>>> DownloadSQLFS


        [HttpGet]
        public ActionResult UploadMaterijal()
        {

<<<<<<< HEAD
            //var materijali = _context.Materijal.ToList();
=======
>>>>>>> DownloadSQLFS

            return View();
        }

        [HttpPost]
        public ActionResult UploadMaterijal(MaterijalModel materijal, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
<<<<<<< HEAD
                if (ModelState.IsValid)
                {

=======
                if (file != null)
                {


>>>>>>> DownloadSQLFS
                    string nazivFajla = Path.GetFileName(file.FileName);

                    materijal.fileMimeType = file.ContentType;
                    materijal.materijalFile = new byte[file.ContentLength];
                    file.InputStream.Read(materijal.materijalFile, 0, file.ContentLength);
                    materijal.materijalNaziv = nazivFajla;
                    materijal.materijalEkstenzija = Path.GetExtension(nazivFajla);

<<<<<<< HEAD
                    _context.Materijal.Add(materijal);
                    _context.SaveChanges();
=======
>>>>>>> DownloadSQLFS
                }

                ViewBag.Message = "Uspešno ste postavili materijal!";
                context.Add<MaterijalModel>(materijal);
                context.SaveChanges();
                return View();
            }
            else
            {
                ViewBag.Message = "Postavljanje materijala nije uspelo!";
                return View();
            }
        }

        public FileContentResult DownloadMaterijal(int id)
        {
            MaterijalModel materijal = context.pronadjiMaterijalPoId(id);
            if (materijal != null)
            {
                return File(materijal.materijalFile, materijal.fileMimeType, materijal.materijalNaziv);
            }
            else
            {
                return null;
            }
        }

        public ActionResult Delete(int id)
        {
            MaterijalModel materijal = context.pronadjiMaterijalPoId(id);
            if (materijal == null)
            {
                return HttpNotFound();
            }
            return View("Delete", materijal);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterijalModel materijal = context.pronadjiMaterijalPoId(id);
            context.Delete<MaterijalModel>(materijal);
            context.SaveChanges();
            return RedirectToAction("MaterijaliPrikaz");
        }




    }
}