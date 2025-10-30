using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class KhoSanpham
{
    public int Stt { get; set; }

    public string Masp { get; set; } = null!;

    public DateTime Ngaynhap { get; set; }

    public int? Soluongnhap { get; set; }

    public virtual Sanpham MaspNavigation { get; set; } = null!;

    public virtual Khohang SttNavigation { get; set; } = null!;
}
