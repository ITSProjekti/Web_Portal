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

        // TODO:


        //[HttpGet]
        //public ActionResult MaterijaliPrikaz()
        //{
        //    var materijali = _context.Materijal.ToList();
        //    MaterijalViewModel ViewModel = new MaterijalViewModel
        //    {
        //        mater = materijali
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
        public ActionResult UploadMaterijal([Bind(Include = "Title, File")] MaterijalViewModel fileModel)
        {
            if (ModelState.IsValid)
            {
                var fileData = new MemoryStream();
                fileModel.File.InputStream.CopyTo(fileData);


                string nazivFajla = Path.GetFileName(fileModel.File.FileName);
                string tipFajla = Path.GetExtension(fileModel.File.FileName);

                var file = new MaterijalModel { materijalNaziv = nazivFajla, materijalTip = tipFajla, materijalFile = fileData.ToArray() };
                _context.Materijal.Add(file);

                _context.SaveChanges();

                return RedirectToAction("UploadMaterijal");
            }
            return View(fileModel);




        }
    }
}