using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public interface ISanPhamService
    {
        public List<Sanpham> GetAllSP();

        Sanpham GetSanPhamById(string id);

        // hàm tìm sản phẩm theo mã
        List<Sanpham> TimSanPhamTheoMa(string masp);

        // hàm tìm sản phẩm theo tên
        List<Sanpham> TimSanPhamTheoTen(string tensp);

        // hàm thêm sản phẩm
        void AddSanPham(string Tensp, decimal Dongia, string Dvt,
                        string Mota, string Hinhanh, int Soluongton, string Maloai);

        // hàm sửa sản phẩm
        bool EditSanPham(string Masp, string Tensp, decimal Dongia, string Dvt,
                         string Mota, string Hinhanh, int Soluongton, string Maloai);

        // hàm xóa sản phẩm
        bool DeleteSanPham(string Masp);

        // hàm tìm kiếm
        List<Sanpham> TimKiem(string searchMaSp, string searchTenSp, string searchMaLoai);
    }
}