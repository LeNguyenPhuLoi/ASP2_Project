using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class Thanhtoan
{
    public string Matt { get; set; } = null!;

    public string Mahd { get; set; } = null!;

    public string? Phuongthuc { get; set; }

    public DateTime? Ngaytt { get; set; }

    public decimal? Tongtien { get; set; }

    public string? Trangthai { get; set; }

    public virtual Hoadon MahdNavigation { get; set; } = null!;
}
