using WebLinhKienDienTu.Models;
using WebLinhKienDienTu.ViewModels;

namespace WebLinhKienDienTu.Repository
{
    public interface IGioHangService
    {
        //hàm lấy danh sách giỏ hàng theo makh
        public List<GioHangViewModel> LayDanhSachGioHangTheoMaKH(string email);

        //hàm thêm giỏ hàng
        public bool AddGioHang(string email, string masp, int soluong);

        //hàm xóa giỏ hàng theo mã hóa đơn
        public void DeleDeleteHoaDonTheoMahd(string mahoadon);

        //hàm xóa toàn bộ giỏ hàng
        public void DeleteAllGioHang(string email);
    }
}
