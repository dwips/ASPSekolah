using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sekolah.Models;

namespace Sekolah.Controllers
{
    public class MapelsController : Controller
    {
        private JadwalSekolahDBEntities1 db = new JadwalSekolahDBEntities1();

        // GET: Mapels
        public ActionResult Index()
        {
            return View(db.Mapels.ToList());
        }

        // GET: Mapels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mapel mapel = db.Mapels.Find(id);
            if (mapel == null)
            {
                return HttpNotFound();
            }
            return View(mapel);
        }

        // GET: Mapels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mapels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMapel,NamaPelajaran")] Mapel mapel)
        {
            if (ModelState.IsValid)
            {
                db.Mapels.Add(mapel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mapel);
        }

        // GET: Mapels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mapel mapel = db.Mapels.Find(id);
            if (mapel == null)
            {
                return HttpNotFound();
            }
            return View(mapel);
        }

        // POST: Mapels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMapel,NamaPelajaran")] Mapel mapel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mapel);
        }

        // GET: Mapels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mapel mapel = db.Mapels.Find(id);
            if (mapel == null)
            {
                return HttpNotFound();
            }
            return View(mapel);
        }

        // POST: Mapels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mapel mapel = db.Mapels.Find(id);
            db.Mapels.Remove(mapel);
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
