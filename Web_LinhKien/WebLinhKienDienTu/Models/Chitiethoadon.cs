using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class Chitiethoadon
{
    public string Mahd { get; set; } = null!;

    public string Masp { get; set; } = null!;

    public string Makho { get; set; } = null!;

    public int? Soluong { get; set; }

    public decimal? Dongia { get; set; }

    public decimal? Thanhtien { get; set; }

    public virtual Hoadon MahdNavigation { get; set; } = null!;

    public virtual Sanpham MaspNavigation { get; set; } = null!;

    public virtual Khohang? MakhoNavigation { get; set; }
}
