namespace WebLinhKienDienTu.ViewModels
{
    public class ChiTietHoaDonViewModel
    {
        public string Mahd { get; set; } //từ HOADON
        public string Tenkh { get; set; } //từ KHACHHANG
        public DateTime Ngaylap { get; set; } //từ HOADON
        public string TenNV { get; set; } //từ NHANVIEN
        public string Trangthai { get; set; } // từ HOADON
        public string Tensp { get; set; } //từ SANPHAM
        public string Tenkho { get; set; } //từ KHOHANG
        public int Soluong { get; set; } //từ CHITIETHOADON
        public decimal Dongia { get; set; } //từ SANPHAM
    }
}
