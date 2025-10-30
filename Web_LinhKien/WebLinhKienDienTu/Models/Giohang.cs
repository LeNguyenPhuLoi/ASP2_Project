using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class Giohang
{
    public int Magh { get; set; }

    public string Makh { get; set; } = null!;

    public string Masp { get; set; } = null!;

    public int? Soluong { get; set; }

    public string? Mahd { get; set; }

    public virtual ICollection<Chitietgiohang> Chitietgiohangs { get; set; } = new List<Chitietgiohang>();

    public virtual Hoadon? MahdNavigation { get; set; }

    public virtual Khachhang MakhNavigation { get; set; } = null!;

    public virtual Sanpham MaspNavigation { get; set; } = null!;
}
