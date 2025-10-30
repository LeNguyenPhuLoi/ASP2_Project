using System;
using System.Collections.Generic;

namespace WebLinhKienDienTu.Models;

public partial class Lichsuhoatdong
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? Thoigian { get; set; }

    public string? Hoatdong { get; set; }

    public string? Doituong { get; set; }

    public string? Chitiet { get; set; }

    public virtual Taikhoan EmailNavigation { get; set; } = null!;
}
