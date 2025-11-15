using Microsoft.EntityFrameworkCore;
using WebLinhKienDienTu.Models;
namespace WebLinhKienDienTu.Repository
{
    public class KhoSPService : IKhoSPService
    {
        private readonly QllkContext _db;

        public KhoSPService(QllkContext db)
        {
            _db = db;
        }

        // hàm lấy danh sách kho sản phẩm
        public List<KhoSanpham> LayDanhSachKhoSanPham()
        {
            List<KhoSanpham> list = new List<KhoSanpham>();
            list = _db.KhoSanphams.ToList();
            return list;
        }

        // hàm tìm kho sản phẩm theo mã sản phẩm
        public List<KhoSanpham> TimKhoSanPhamTheoMaSP(string masp)
        {
            List<KhoSanpham> list = new List<KhoSanpham>();
            list = _db.KhoSanphams
                .Where(x => x.Masp.StartsWith(masp))
                .ToList();
            return list;
        }

        // hàm thêm kho sản phẩm
        public void AddKhoSanPham(string makho, string masp, DateTime ngaynhap, int soluongnhap)
        {
            var sp = new KhoSanpham
            {
                Makho = makho,
                Masp = masp,
                Ngaynhap = ngaynhap,
                Soluongnhap = soluongnhap
            };
            _db.KhoSanphams.Add(sp);
            _db.SaveChanges();
        }

        // hàm sửa kho sản phẩm
        public bool EditKhoSanPham(string makho, string masp, DateTime ngaynhap, int soluongnhap)
        {
            bool flag = false;
            var sp = _db.KhoSanphams.FirstOrDefault(k => k.Makho == makho);
            if (sp != null)
            {
                sp.Masp = masp;
                sp.Ngaynhap = ngaynhap;
                sp.Soluongnhap = soluongnhap;
                _db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        // hàm xóa kho sản phẩm
        public bool DeleteKhoSanPham(string makho)
        {
            bool flag = false;
            var sp = _db.KhoSanphams.FirstOrDefault(k => k.Makho == makho);
            if (sp != null)
            {
                _db.KhoSanphams.Remove(sp);
                _db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        // hàm tìm kiếm
        public List<KhoSanpham> TimKiem(string searchMaSP)
        {
            var query = _db.KhoSanphams.AsQueryable();

            if (!string.IsNullOrEmpty(searchMaSP))
            {
                query = query.Where(k => k.Masp.Contains(searchMaSP));
            }

            return query.ToList();
        }
    }
}
