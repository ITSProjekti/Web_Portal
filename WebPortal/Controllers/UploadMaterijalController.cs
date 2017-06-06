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
        private ApplicationDbContext _context;

        public UploadMaterijalController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

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


        [HttpGet]
        public ActionResult UploadMaterijal()
        {

            //var materijali = _context.Materijal.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult UploadMaterijal(MaterijalModel materijal, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string nazivFajla = Path.GetFileName(file.FileName);

                    materijal.fileMimeType = file.ContentType;
                    materijal.materijalFile = new byte[file.ContentLength];
                    file.InputStream.Read(materijal.materijalFile, 0, file.ContentLength);
                    materijal.materijalNaziv = nazivFajla;
                    materijal.materijalEkstenzija = Path.GetExtension(nazivFajla);

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

        //[HttpPost]
        //public ActionResult UploadMaterijal([Bind(Include = "Title, File")] MaterijalViewModel fileModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var fileData = new MemoryStream();
        //        fileModel.File.InputStream.CopyTo(fileData);

        //        string nazivFajla = Path.GetFileName(fileModel.File.FileName);
        //        string tipFajla = Path.GetExtension(fileModel.File.FileName);

        //        var file = new MaterijalModel { materijalNaziv = nazivFajla, materijalTip = tipFajla, materijalFile = fileData.ToArray() };
        //        _context.Materijal.Add(file);

        //        _context.SaveChanges();

        //        return RedirectToAction("UploadMaterijal");
        //    }
        //    return View(fileModel);
        //}

    }
}