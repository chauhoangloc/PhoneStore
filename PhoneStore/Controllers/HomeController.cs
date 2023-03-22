using PhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhoneStore.Models;
namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        phonestoreEntities db = new phonestoreEntities();
        public ActionResult Index(int MaLoaiSP = 0, string SearchString = "")
        {
            if (SearchString != "")
            {
                var sanpham = db.SanPhams.Include(s => s.LoaiSanPham).Where(x => x.TenSanPham.ToUpper().Contains(SearchString.ToUpper()));
                return View(sanpham.ToList());
            }
            else
            if (MaLoaiSP == 0)
            {
                var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham).OrderBy(x => x.TenSanPham);

                return View(sanPhams.ToList());
            }
            else
            {
                var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham).Where(x => x.MaLoaiSanPham == MaLoaiSP);
                return View(sanPhams.ToList());
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}