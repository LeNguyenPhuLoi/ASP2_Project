using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public interface ISanPhamService
    {
        public List<Sanpham> GetAllSP();

        Sanpham GetSanPhamById(string id);
    }
}