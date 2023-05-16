using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models;


namespace PhoneStore.Controllers
{
    [Authorize(Roles = "Admin,Emp")]
    public class HomeAdminController : Controller
    {
        phonestoreEntities2 db = new phonestoreEntities2();
        // GET: HomeAdmin
        public ActionResult Index(int? nam)
        {
            ViewBag.SoNguoiTruyCap = HttpContext.Application["SoNguoiTruyCap"].ToString();
            ViewBag.SoNguoiOnline = HttpContext.Application["SoNguoiOnline"].ToString();
            if (nam == null)
            {
                var hoaDons = db.HoaDons.Where(n => n.NgayLapHoaDon.Value.Year == nam);
                var data = hoaDons
               .GroupBy(n => n.NgayLapHoaDon.Value.Month)
               .Select(n => new { Thang = n.Key, DoanhThu = n.Sum(m => m.TongTien) })
               .OrderBy(n => n.Thang)
               .ToList();
                ViewBag.Data = new[] {
                new object[] { data.FirstOrDefault(n => n.Thang == 1)?.DoanhThu ?? 0 },
                new object[] { data.FirstOrDefault(n => n.Thang == 2)?.DoanhThu ?? 0 },
                new object[] { data.FirstOrDefault(n => n.Thang == 3)?.DoanhThu ?? 0 },
                new object[] { data.FirstOrDefault(n => n.Thang == 4)?.DoanhThu ?? 0 },
                new object[] { data.FirstOrDefault(n => n.Thang == 5)?.DoanhThu ?? 0 },
                new object[] { data.FirstOrDefault(n => n.Thang == 6)?.DoanhThu ?? 0 },
                new object[] { data.FirstOrDefault(n => n.Thang == 7)?.DoanhThu ?? 0 },
                new object[] { data.FirstOrDefault(n => n.Thang == 8)?.DoanhThu ?? 0 },
                new object[] { data.FirstOrDefault(n => n.Thang == 9)?.DoanhThu ?? 0 },
                new object[] { data.FirstOrDefault(n => n.Thang == 10)?.DoanhThu ?? 0 },
                new object[] { data.FirstOrDefault(n => n.Thang == 11)?.DoanhThu ?? 0 },
                new object[] { data.FirstOrDefault(n => n.Thang == 12)?.DoanhThu ?? 0 }

                };
            }
            else
            {
                var hoaDons = db.HoaDons.Where(n => n.NgayLapHoaDon.Value.Year == nam);
                var data = hoaDons
               .GroupBy(n => n.NgayLapHoaDon.Value.Month)
               .Select(n => new { Thang = n.Key, DoanhThu = n.Sum(m => m.TongTien) })
               .OrderBy(n => n.Thang)
               .ToList();
                ViewBag.Data = new[] {
                    new object[] { data.FirstOrDefault(n => n.Thang == 1)?.DoanhThu ?? 0 },
                    new object[] { data.FirstOrDefault(n => n.Thang == 2)?.DoanhThu ?? 0 },
                    new object[] { data.FirstOrDefault(n => n.Thang == 3)?.DoanhThu ?? 0 },
                    new object[] { data.FirstOrDefault(n => n.Thang == 4)?.DoanhThu ?? 0 },
                    new object[] { data.FirstOrDefault(n => n.Thang == 5)?.DoanhThu ?? 0 },
                    new object[] { data.FirstOrDefault(n => n.Thang == 6)?.DoanhThu ?? 0 },
                    new object[] { data.FirstOrDefault(n => n.Thang == 7)?.DoanhThu ?? 0 },
                    new object[] { data.FirstOrDefault(n => n.Thang == 8)?.DoanhThu ?? 0 },
                    new object[] { data.FirstOrDefault(n => n.Thang == 9)?.DoanhThu ?? 0 },
                    new object[] { data.FirstOrDefault(n => n.Thang == 10)?.DoanhThu ?? 0 },
                    new object[] { data.FirstOrDefault(n => n.Thang == 11)?.DoanhThu ?? 0 },
                    new object[] { data.FirstOrDefault(n => n.Thang == 12)?.DoanhThu ?? 0 }
                };
            }
            return View();
        }
    }
}