using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public class SanPhamService: ISanPhamService
    {
        private readonly QllkContext _db;
        public SanPhamService(QllkContext db)
        {
            _db = db;
        }
        public List<Sanpham> GetAllSP()
        {
            Console.WriteLine(">>> QllkContext null? " + (_db == null));
            return _db.Sanphams.ToList();
        }
    }
}
