using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneStore.Models
{
    public class Cart
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double GiaBan { get; set; }
        public int SoLuong { get; set; }
        public double TongTien
        {
            get { return SoLuong * GiaBan; }
        }
    }
}