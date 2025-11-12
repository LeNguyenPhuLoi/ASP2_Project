using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class Hoadon
{
    public string Mahd { get; set; } = null!;

    public DateTime? Ngaylap { get; set; }

    public decimal? Tongtien { get; set; }

    public string? Makh { get; set; }

    public string? Manv { get; set; }

    public string? Trangthai { get; set; }

    public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; } = new List<Chitiethoadon>();

    public virtual ICollection<Giohang> Giohangs { get; set; } = new List<Giohang>();

    public virtual ICollection<Lichsumuahang> Lichsumuahangs { get; set; } = new List<Lichsumuahang>();

    public virtual Khachhang? MakhNavigation { get; set; }

    public virtual Nhanvien? ManvNavigation { get; set; }

    public virtual ICollection<Thanhtoan> Thanhtoans { get; set; } = new List<Thanhtoan>();
}
