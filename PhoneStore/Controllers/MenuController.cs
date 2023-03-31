using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models;
using System.Collections;
namespace PhoneStore.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            using (phonestoreEntities1 db = new phonestoreEntities1())
            {
                var loaisp = db.LoaiSanPhams.ToList();
                Hashtable tenLoaiSP = new Hashtable();
                foreach (var item in loaisp)
                {
                    tenLoaiSP.Add(item.MaLoaiSanPham, item.TenLoaiSanPham);
                }
                ViewBag.TenLoaiSP = tenLoaiSP;
                return PartialView("Index");
            }
        }
    }
}