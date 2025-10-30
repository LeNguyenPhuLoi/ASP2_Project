using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class Khachhang
{
    public string Makh { get; set; } = null!;

    public string? Tenkh { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? Diachi { get; set; }

    public DateTime? Ngaytao { get; set; }

    public virtual Taikhoan? EmailNavigation { get; set; }

    public virtual ICollection<Giohang> Giohangs { get; set; } = new List<Giohang>();

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();

    public virtual ICollection<Lichsumuahang> Lichsumuahangs { get; set; } = new List<Lichsumuahang>();
}
