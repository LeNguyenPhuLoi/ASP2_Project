using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class Nhanvien
{
    public string Manv { get; set; } = null!;

    public string Tennv { get; set; } = null!;

    public string? Gioitinh { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Chuc { get; set; }

    public decimal? Luong { get; set; }

    public string? Diachi { get; set; }

    public int? Sdt { get; set; }

    public string? Email { get; set; }

    public virtual Taikhoan? EmailNavigation { get; set; }

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();
}
