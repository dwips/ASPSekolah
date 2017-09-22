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
    public class GurusController : Controller
    {
        private JadwalSekolahDBEntities1 db = new JadwalSekolahDBEntities1();

        // GET: Gurus
        public ActionResult Index()
        {
            return View(db.Gurus.ToList());
        }

        // GET: Gurus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guru guru = db.Gurus.Find(id);
            if (guru == null)
            {
                return HttpNotFound();
            }
            return View(guru);
        }

        // GET: Gurus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gurus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGuru,NamaGuru,Alamat,TahunMulaiMengajar,Email")] Guru guru)
        {
            if (ModelState.IsValid)
            {
                db.Gurus.Add(guru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guru);
        }

        // GET: Gurus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guru guru = db.Gurus.Find(id);
            if (guru == null)
            {
                return HttpNotFound();
            }
            return View(guru);
        }

        // POST: Gurus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGuru,NamaGuru,Alamat,TahunMulaiMengajar,Email")] Guru guru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guru);
        }

        // GET: Gurus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guru guru = db.Gurus.Find(id);
            if (guru == null)
            {
                return HttpNotFound();
            }
            return View(guru);
        }

        // POST: Gurus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guru guru = db.Gurus.Find(id);
            db.Gurus.Remove(guru);
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
