using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class Lichsumuahang
{
    public string Malsmh { get; set; } = null!;

    public string Makh { get; set; } = null!;

    public string Mahd { get; set; } = null!;

    public DateTime? Ngaymua { get; set; }

    public decimal? Tongtien { get; set; }

    public string? Trangthai { get; set; }

    public virtual Hoadon MahdNavigation { get; set; } = null!;

    public virtual Khachhang MakhNavigation { get; set; } = null!;
}
