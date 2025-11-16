using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public interface ILichSuMuaHangService
    {
        //hàm lấy hóa đơn theo mã khách hàng
        public List<Hoadon> LayDanhSachHoaDonTheoEmail(string email);

        //hàm tìm kiếm
        public List<Hoadon> TimKiem(string searchMa, string searchTrangThai, string searchNgay, string email);
    }
}
