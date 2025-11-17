using WebLinhKienDienTu.ViewModels;

namespace WebLinhKienDienTu.Repository
{
    public interface IThanhToanService
    {
        //hàm lấy danh sách giỏ hàng theo makh
        public List<GioHangViewModel> LayDanhSachGioHangTheoMaKH(string email);
    }
}