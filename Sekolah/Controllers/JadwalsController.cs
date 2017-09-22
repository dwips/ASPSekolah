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
    public class JadwalsController : Controller
    {
        private JadwalSekolahDBEntities1 db = new JadwalSekolahDBEntities1();

        // GET: Jadwals
        public ActionResult Index()
        {
            var jadwals = db.Jadwals.Include(j => j.Guru).Include(j => j.Mapel);
            return View(jadwals.ToList());
        }

        // GET: Jadwals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jadwal jadwal = db.Jadwals.Find(id);
            if (jadwal == null)
            {
                return HttpNotFound();
            }
            return View(jadwal);
        }

        // GET: Jadwals/Create
        public ActionResult Create()
        {
            ViewBag.IdGuru = new SelectList(db.Gurus, "IdGuru", "NamaGuru");
            ViewBag.IdMapel = new SelectList(db.Mapels, "IdMapel", "NamaPelajaran");
            return View();
        }

        // POST: Jadwals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdJadwal,Kelas,Waktu,IdMapel,IdGuru")] Jadwal jadwal)
        {
            if (ModelState.IsValid)
            {
                db.Jadwals.Add(jadwal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGuru = new SelectList(db.Gurus, "IdGuru", "NamaGuru", jadwal.IdGuru);
            ViewBag.IdMapel = new SelectList(db.Mapels, "IdMapel", "NamaPelajaran", jadwal.IdMapel);
            return View(jadwal);
        }

        // GET: Jadwals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jadwal jadwal = db.Jadwals.Find(id);
            if (jadwal == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGuru = new SelectList(db.Gurus, "IdGuru", "NamaGuru", jadwal.IdGuru);
            ViewBag.IdMapel = new SelectList(db.Mapels, "IdMapel", "NamaPelajaran", jadwal.IdMapel);
            return View(jadwal);
        }

        // POST: Jadwals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdJadwal,Kelas,Waktu,IdMapel,IdGuru")] Jadwal jadwal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jadwal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGuru = new SelectList(db.Gurus, "IdGuru", "NamaGuru", jadwal.IdGuru);
            ViewBag.IdMapel = new SelectList(db.Mapels, "IdMapel", "NamaPelajaran", jadwal.IdMapel);
            return View(jadwal);
        }

        // GET: Jadwals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jadwal jadwal = db.Jadwals.Find(id);
            if (jadwal == null)
            {
                return HttpNotFound();
            }
            return View(jadwal);
        }

        // POST: Jadwals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jadwal jadwal = db.Jadwals.Find(id);
            db.Jadwals.Remove(jadwal);
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
