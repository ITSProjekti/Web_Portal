using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPortal.Models;

namespace WebPortal.Controllers
{
    public class MaterijalModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MaterijalModels
        public ActionResult Index()
        {
            return View(db.Materijal.ToList());
        }

        //public FileContentResult ViewModel(int id)
        //{
        //    if (id == 0) { return null; }
        //    MaterijalModel resume = new MaterijalModel();

        //    resume = db.Materijal.Where(a => a.materijalId == id).SingleOrDefault();
        //    Response.AppendHeader("content-disposition", "inline; filename = file.pdf"); //this will open in a new tab.. remove if you want to open in the same tab.
        //    return File(resume.materijalFile, "application/pdf");
        //}

        // GET: MaterijalModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterijalModel materijalModel = db.Materijal.Find(id);
            if (materijalModel == null)
            {
                return HttpNotFound();
            }
            return View(materijalModel);
        }

        // GET: MaterijalModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaterijalModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "materijalId,mate rijalFile,materijalUrl,materijalTip,materijalNaziv")] MaterijalModel materijalModel)
        {
            if (ModelState.IsValid)
            {
                db.Materijal.Add(materijalModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materijalModel);
        }

        // GET: MaterijalModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterijalModel materijalModel = db.Materijal.Find(id);
            if (materijalModel == null)
            {
                return HttpNotFound();
            }
            return View(materijalModel);
        }

        // POST: MaterijalModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "materijalId,materijalFile,materijalUrl,materijalTip,materijalNaziv")] MaterijalModel materijalModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materijalModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materijalModel);
        }

        // GET: MaterijalModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterijalModel materijalModel = db.Materijal.Find(id);
            if (materijalModel == null)
            {
                return HttpNotFound();
            }
            return View(materijalModel);
        }

        // POST: MaterijalModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterijalModel materijalModel = db.Materijal.Find(id);
            db.Materijal.Remove(materijalModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
