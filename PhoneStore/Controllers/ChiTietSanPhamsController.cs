using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models;

namespace PhoneStore.Controllers
{
    [Authorize(Roles = "Admin,Emp")]
    public class ChiTietSanPhamsController : Controller
    {
        private phonestoreEntities2 db = new phonestoreEntities2();

        // GET: ChiTietSanPhams
        public ActionResult Index()
        {
            var chiTietSanPhams = db.ChiTietSanPhams.Include(c => c.SanPham);
            return View(chiTietSanPhams.ToList());
        }

        // GET: ChiTietSanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSanPham chiTietSanPham = db.ChiTietSanPhams.Find(id);
            if (chiTietSanPham == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSanPham);
        }

        // GET: ChiTietSanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: ChiTietSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChiTietSanPham,MaSanPham,SoLuongTrongKho,MauSac")] ChiTietSanPham chiTietSanPham)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietSanPhams.Add(chiTietSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietSanPham.MaSanPham);
            return View(chiTietSanPham);
        }

        // GET: ChiTietSanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSanPham chiTietSanPham = db.ChiTietSanPhams.Find(id);
            if (chiTietSanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietSanPham.MaSanPham);
            return View(chiTietSanPham);
        }

        // POST: ChiTietSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChiTietSanPham,MaSanPham,SoLuongTrongKho,MauSac")] ChiTietSanPham chiTietSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietSanPham.MaSanPham);
            return View(chiTietSanPham);
        }

        // GET: ChiTietSanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSanPham chiTietSanPham = db.ChiTietSanPhams.Find(id);
            if (chiTietSanPham == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSanPham);
        }

        // POST: ChiTietSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietSanPham chiTietSanPham = db.ChiTietSanPhams.Find(id);
            db.ChiTietSanPhams.Remove(chiTietSanPham);
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
