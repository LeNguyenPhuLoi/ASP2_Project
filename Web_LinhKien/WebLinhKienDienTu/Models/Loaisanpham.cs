using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class Loaisanpham
{
    public string Maloai { get; set; } = null!;

    public string? Tenloai { get; set; }

    public string? Mota { get; set; }

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
