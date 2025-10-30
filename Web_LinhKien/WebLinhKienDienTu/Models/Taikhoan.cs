using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class Taikhoan
{
    public string Email { get; set; } = null!;

    public string? Pass { get; set; }

    public string? Quyen { get; set; }

    public string? Trangthai { get; set; }

    public virtual ICollection<Khachhang> Khachhangs { get; set; } = new List<Khachhang>();

    public virtual ICollection<Lichsuhoatdong> Lichsuhoatdongs { get; set; } = new List<Lichsuhoatdong>();

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}
