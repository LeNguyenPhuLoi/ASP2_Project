using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public interface IKhachHangService
    {
        public List<Khachhang> LoadDSKhachHang();
        Task AddCustomer(string tenkh, string sdt, string email, string pass, string diachi);
        public bool EditCustomer(string makh, string tenkh, string sdt, string diachi);
        public Task<bool> DeleteCustomer(string makh);
        public List<Khachhang> TimKiem(string searchMa, string searchKhachHang);
    }
}
