using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public interface IHoaDonService
    {
        //hàm lấy danh sách hóa đơn
        public List<Hoadon> LayDanhSachHoaDon();

        //hàm thêm hóa đơn
        public void AddHoaDon(string Makh, string Ngaylap, string Manv, string Tongtien, string Trangthai);

        //hàm sửa hóa đơn
        public bool EditHoaDon(string Mahoadon, string Makh, string Ngaylap, string Manv, string Tongtien, string Trangthai);

        //hàm xóa hóa đơn
        public bool DeleteHoaDon(string Mahoadon);

        //hàm tìm kiếm
        public List<Hoadon> TimKiem(string searchMa, string searchKhachHang, string searchTrangThai);
    }
}
