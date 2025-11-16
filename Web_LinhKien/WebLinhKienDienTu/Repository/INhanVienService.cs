using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public interface INhanVienService
    {
        public List<Nhanvien> LoadDSNhanVien();
        Task AddNhanVien(string tennv, string sdt, string gioitinh, string ngaysinh,
                              string chuc, string luong, string email, string pass, string diachi);
        public bool EditNhanVien(string manv, string tennv, string sdt, string gioitinh, string ngaysinh,
                              string chuc, string luong, string diachi);
        Task<bool> DeleteNhanVien(string manv);
        public List<Nhanvien> TimKiem(string searchMa, string searchTen);
    }

}
