using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public interface ILoaiSPService
    {
        //hàm lấy danh sách loại sản phẩm
        public List<Loaisanpham> LayDanhSachLoaiSanPham();

        //hàm tìm loại sản phẩm theo mã loại
        public List<Loaisanpham> TimLoaiSanPhamTheoMaLoai(string maloai);

        //hàm tìm loại sản phẩm theo tên loại
        public List<Loaisanpham> TimLoaiSanPhamTheoTenLoai(string tenloai);

        //hàm thêm loại sản phẩm
        public void AddLoaiSanPham(string Tenloai, string Mota);

        //hàm sửa loại sản phẩm
        public bool EditLoaiSanPham(string Maloai, string Tenloai, string Mota);

        //hàm xóa loại sản phẩm
        public bool DeleteLoaiSanPham(string Maloai);

        //hàm tìm kiếm
        public List<Loaisanpham> TimKiem(string searchMaLoai, string searchTenLoai);
    }
}