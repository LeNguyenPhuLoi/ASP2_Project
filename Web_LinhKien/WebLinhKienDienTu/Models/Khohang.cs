using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class Khohang
{
    public string Makho { get; set; } = null!;

    public string Tenkho { get; set; } = null!;

    public string? Diachikho { get; set; }

    public string? Manv { get; set; }

    public string? Soluongloaihang { get; set; }

    public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; } = new List<Chitiethoadon>();

    public virtual ICollection<KhoSanpham> KhoSanphams { get; set; } = new List<KhoSanpham>();
}
