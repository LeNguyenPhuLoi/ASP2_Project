using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public interface IKhoHangService
    {
        //hàm lấy danh sách kho hàng
        public List<Khohang> LayDanhSachKhoHang();

        //hàm tìm kho hàng theo mã kho
        public List<Khohang> TimKhoHangTheoMaKho(string makho);

        //hàm tìm kho hàng theo tên kho
        public List<Khohang> TimKhoHangTheoTenKho(string tenkho);

        //hàm thêm kho hàng
        public void AddKhoHang(string Makho, string Tenkho, string Diachi, string Manv, string Soluongloaihang);

        //hàm sửa kho hàng
        public bool EditKhoHang(string Makho, string Tenkho, string Diachi, string Manv, string Soluongloaihang);

        //hàm xóa kho hàng
        public bool DeleteKhoHang(string Makho);
        public List<Khohang> TimKiem(string searchMaKho, string searchTenKho);
    }
}
