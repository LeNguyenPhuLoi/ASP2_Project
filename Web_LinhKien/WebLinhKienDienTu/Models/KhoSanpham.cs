using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class KhoSanpham
{
    public string Makho { get; set; } = null!;

    public string Masp { get; set; } = null!;

    public DateTime Ngaynhap { get; set; }

    public int? Soluongnhap { get; set; }

    public virtual Sanpham MaspNavigation { get; set; } = null!;

    public virtual Khohang MakhoNavigation { get; set; } = null!;
}
