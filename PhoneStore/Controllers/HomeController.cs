﻿using PhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhoneStore.Models;
using PagedList;
namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        phonestoreEntities db = new phonestoreEntities();
        public ActionResult Index(string currentFilter, int? page, int MaLoaiSP = 0, string SearchString = "")
        {
            if (SearchString != "")
            {
                page = 1;
                var sanpham = db.SanPhams.Include(s => s.LoaiSanPham).Where(x => x.TenSanPham.ToUpper().Contains(SearchString.ToUpper()));
                return View(sanpham.ToList());
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