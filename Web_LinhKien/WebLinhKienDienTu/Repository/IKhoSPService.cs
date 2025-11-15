using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public interface IKhoSPService
    {
        //hàm lấy danh sách kho sản phẩm
        public List<KhoSanpham> LayDanhSachKhoSanPham();

        //hàm tìm kho sản phẩm theo mã sản phẩm
        public List<KhoSanpham> TimKhoSanPhamTheoMaSP(string masp);

        //hàm thêm kho sản phẩm
        public void AddKhoSanPham(string makho, string masp, DateTime ngaynhap, int soluongnhap);

        //hàm sửa kho sản phẩm
        public bool EditKhoSanPham(string makho, string masp, DateTime ngaynhap, int soluongnhap);

        //hàm xóa kho sản phẩm
        public bool DeleteKhoSanPham(string makho);

        //hàm tìm kiếm kho sản phẩm
        public List<KhoSanpham> TimKiem(string searchMaSP);
    }
}