using PhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;

namespace PhoneStore.Controllers
{
    public class shoppingController : Controller
    {
        // GET: shopping
        phonestoreEntities2 db = new phonestoreEntities2();
        public ActionResult Index(string currentFilter, int? page, int MaLoaiSP = 0, string SearchString = "")
        {
            if (SearchString != "")
            {
                page = 1;
                var sanpham = db.SanPhams.Include(s => s.LoaiSanPham).Where(x => x.TenSanPham.ToUpper().Contains(SearchString.ToUpper()));
                int pageSize = sanpham.Count();
                int pageNumber = (page ?? 1);
                sanpham = sanpham.OrderBy(x => x.TenSanPham);
                return View(sanpham.ToPagedList(pageNumber, pageSize));
            }
            else
                SearchString = currentFilter;
            ViewBag.CurrentFilter = currentFilter;
            if (MaLoaiSP == 0)
            {
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham).OrderBy(x => x.TenSanPham);

                return View(sanPhams.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham).Where(x => x.MaLoaiSanPham == MaLoaiSP);
                sanPhams = sanPhams.OrderBy(x => x.TenSanPham);
                int pageSize = sanPhams.Count();
                int pageNumber = (page ?? 1);
                return View(sanPhams.ToPagedList(pageNumber, pageSize));
            }
        }
    }
}