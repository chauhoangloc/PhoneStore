using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models;
using System.IO;

namespace PhoneStore.Controllers
{
    public class SanPhamsController : Controller
    {
        private phonestoreEntities db = new phonestoreEntities();

        // GET: SanPhams
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham);
            return View(sanPhams.ToList());
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,TenSanPham,MaLoaiSanPham,DaBan,GiaBan,HinhAnh")] SanPham sanPham, HttpPostedFileBase HinhSP)
        {
            if (ModelState.IsValid)
            {
                if (HinhSP != null && HinhSP.ContentLength > 0)
                {
                    string filename = Path.GetFileName(HinhSP.FileName);
                    string path = Server.MapPath("~/Images/" + filename);
                    sanPham.HinhAnh = "Images/" + filename;
                    HinhSP.SaveAs(path);
                }
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,TenSanPham,MaLoaiSanPham,DaBan,GiaBan,HinhAnh")] SanPham sanPham, HttpPostedFileBase HinhSP)
        {
            if (ModelState.IsValid)
            {
                if (HinhSP != null && HinhSP.ContentLength > 0)
                {
                    string filename = Path.GetFileName(HinhSP.FileName);
                    string path = Server.MapPath("~/Images/" + filename);
                    sanPham.HinhAnh = "Images/" + filename;
                    HinhSP.SaveAs(path);
                }
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
