using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models;
using System.Net;
using System.Net.Mail;
namespace PhoneStore.Controllers
{
    public class CartController : Controller
    {
        private phonestoreEntities2 db = new phonestoreEntities2();
        // GET: Cart
        public ActionResult Index()
        {
            List<Cart> giohang = Session["giohang"] as List<Cart>;
            return View(giohang);
        }

        public RedirectToRouteResult AddToCart(int MaSanPham)
        {
            if (Session["giohang"] == null)
            {
                Session["giohang"] = new List<Cart>();
            }
            List<Cart> giohang = Session["giohang"] as List<Cart>;
            if (giohang.FirstOrDefault(m => m.MaSanPham == MaSanPham) == null)
            {
                SanPham sp = db.SanPhams.Find(MaSanPham);
                Cart newItem = new Cart();
                newItem.MaSanPham = MaSanPham;
                newItem.TenSanPham = sp.TenSanPham;
                newItem.SoLuong = 1;
                newItem.GiaBan = Convert.ToDouble(sp.GiaBan);
                giohang.Add(newItem);
            }
            else
            {
                Cart cart = giohang.FirstOrDefault(m => m.MaSanPham == MaSanPham);
                cart.SoLuong++;
            }
            Session["giohang"] = giohang;
            return RedirectToAction("Index");


        }
        public RedirectToRouteResult Update(int MaSP, int txtSoLuong)
        {
            List<Cart> giohang = Session["gioHang"] as List<Cart>;
            Cart item = giohang.FirstOrDefault(m => m.MaSanPham == MaSP);
            if (item != null)
            {
                item.SoLuong = txtSoLuong;
                Session["giohang"] = giohang;
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult Del(int MaSP)
        {
            List<Cart> giohang = Session["giohang"] as List<Cart>;
            Cart item = giohang.FirstOrDefault(m => m.MaSanPham == MaSP);
            if (item != null)
            {
                giohang.Remove(item);
                Session["giohang"] = giohang;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Payment()
        {
            List<Cart> giohang = Session["giohang"] as List<Cart>;
            var list = new List<Cart>();
            if (giohang != null)
            {
                list = (List<Cart>)giohang;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address)
        {
            var order = new HoaDon();
            order.NgayLapHoaDon = DateTime.Now;
            order.shipadd = address;
            order.shipsdt = Convert.ToInt32(mobile);
            order.shipname = shipName;
            order.TongTien = 100000;


            try
            {

                //Thêm Order               
                db.HoaDons.Add(order);
                db.SaveChanges();
                var id = order.MaHoaDon;

                List<Cart> giohang = Session["giohang"] as List<Cart>;

                foreach (var item in giohang)
                {
                    var orderDetail = new ChiTietHoaDon();
                    orderDetail.MaSanPham = item.MaSanPham;
                    orderDetail.MaHoaDon = id;
                    orderDetail.GiaBan = (Decimal)item.GiaBan;
                    orderDetail.SoLuongMua = item.SoLuong;
                    db.ChiTietHoaDons.Add(orderDetail);
                    db.SaveChanges();
                }

                Session["giohang"] = null;
            }
            catch (Exception ex)
            {
                return Redirect("/Cart/Fails");
            }
            return Redirect("/Cart/Pass");
        }
        public ActionResult Pass()
        {
            return View();
        }
        public ActionResult Fails()
        {
            return View();
        }
        //public ActionResult Order(string Email, string Phone)
        //{
        //    List<Cart> giohang = Session["giohang"] as List<Cart>;
        //    string sMsg = "<html><body><table border='1'><capiton>Thông Tin Đặt Hàng </caption><tr><th>STT</th><th>Tên Hàng</th><th>Số Lượng </th><th>Đơn Giá</th><th>Thành Tiền</th></tr>";
        //    int i = 0;
        //    double tongtien = 0;
        //    foreach (Cart item in giohang)
        //    {
        //        i++;
        //        sMsg += "<tr>";
        //        sMsg += "<td>" + i.ToString() + "</td>";
        //        sMsg += "<td>" + item.TenSanPham + "</td>";
        //        sMsg += "<td>" + item.SoLuong.ToString() + "</td>";
        //        sMsg += "<td>" + item.GiaBan.ToString() + "</td>";
        //        sMsg += "<td>" + String.Format("{0:#,###}", item.SoLuong * item.GiaBan) + "</td>";
        //        sMsg += "</tr>";
        //        tongtien += item.SoLuong + item.GiaBan;
        //    }
        //    sMsg += "<tr><th colspan='5'> Tổng Cộng: "
        //        + String.Format("{):#,### Vnđ }", tongtien) + "</th></tr></table";
        //    MailMessage mail = new MailMessage("diachimailnguoigoi@gmail.com", Email, "Thông Tin đơn hàng", sMsg);
        //    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        //    client.EnableSsl = true;
        //    client.Credentials = new NetworkCredential("diachimailnguoigoi", "matkhau");
        //    mail.IsBodyHtml = true;
        //    client.Send(mail);
        //    return RedirectToAction("Index", "Home");
        //}
    }
}