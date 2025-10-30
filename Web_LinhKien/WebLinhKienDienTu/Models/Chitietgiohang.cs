using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class Chitietgiohang
{
    public int Magh { get; set; }

    public string Masp { get; set; } = null!;

    public int? Soluong { get; set; }

    public decimal? Dongia { get; set; }

    public decimal? Thanhtien { get; set; }

    public virtual Giohang MaghNavigation { get; set; } = null!;

    public virtual Sanpham MaspNavigation { get; set; } = null!;
}
