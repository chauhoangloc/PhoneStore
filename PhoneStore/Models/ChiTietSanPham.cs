//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhoneStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietSanPham
    {
        public int MaChiTietSanPham { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuongTrongKho { get; set; }
        public string MauSac { get; set; }
    
        public virtual SanPham SanPham { get; set; }
    }
}
