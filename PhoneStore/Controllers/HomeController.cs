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
        public ActionResult Index()
        {
            var sanphams = db.SanPhams.Include(s => s.LoaiSanPham);
            return View(sanphams.ToList());

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