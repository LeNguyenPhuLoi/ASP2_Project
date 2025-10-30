using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class Sanpham
{
    public string Masp { get; set; } = null!;

    public string? Tensp { get; set; }

    public decimal? Dongia { get; set; }

    public string? Dvt { get; set; }

    public string? Mota { get; set; }

    public string? Hinhanh { get; set; }

    public int? Soluongton { get; set; }

    public string? Maloai { get; set; }

    public virtual ICollection<Chitietgiohang> Chitietgiohangs { get; set; } = new List<Chitietgiohang>();

    public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; } = new List<Chitiethoadon>();

    public virtual ICollection<Giohang> Giohangs { get; set; } = new List<Giohang>();

    public virtual ICollection<KhoSanpham> KhoSanphams { get; set; } = new List<KhoSanpham>();

    public virtual Loaisanpham? MaloaiNavigation { get; set; }
}
