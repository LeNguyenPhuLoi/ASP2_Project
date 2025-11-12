using Microsoft.EntityFrameworkCore;
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

        public Sanpham GetSanPhamById(string id)
        {
            return _db.Sanphams.FirstOrDefault(x => x.Masp == id);
        }

        // hàm tìm sản phẩm theo mã
        public List<Sanpham> TimSanPhamTheoMa(string masp)
        {
            return _db.Sanphams
                .Where(x => x.Masp.StartsWith(masp))
                .ToList();
        }

        // hàm tìm sản phẩm theo tên
        public List<Sanpham> TimSanPhamTheoTen(string tensp)
        {
            return _db.Sanphams
                .Where(x => x.Tensp.Contains(tensp))
                .ToList();
        }

        // hàm thêm sản phẩm
        public void AddSanPham(string Tensp, decimal Dongia, string Dvt,
                               string Mota, string Hinhanh, int Soluongton, string Maloai)
        {
            string masp;
            int moi = _db.Sanphams.Count() + 1;
            masp = "SP" + moi.ToString("D3");

            var sp = new Sanpham
            {
                Masp = masp,
                Tensp = Tensp,
                Dongia = Dongia,
                Dvt = Dvt,
                Mota = Mota,
                Hinhanh = Hinhanh,
                Soluongton = Soluongton,
                Maloai = Maloai
            };
            _db.Sanphams.Add(sp);
            _db.SaveChanges();
        }

        // hàm sửa sản phẩm
        public bool EditSanPham(string Masp, string Tensp, decimal Dongia, string Dvt,
                                string Mota, string Hinhanh, int Soluongton, string Maloai)
        {
            bool flag = false;
            var sp = _db.Sanphams.FirstOrDefault(k => k.Masp == Masp);
            if (sp != null)
            {
                sp.Tensp = Tensp;
                sp.Dongia = Dongia;
                sp.Dvt = Dvt;
                sp.Mota = Mota;
                sp.Hinhanh = Hinhanh;
                sp.Soluongton = Soluongton;
                sp.Maloai = Maloai;

                _db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        // hàm xóa sản phẩm
        public bool DeleteSanPham(string Masp)
        {
            bool flag = false;
            var sp = _db.Sanphams.FirstOrDefault(k => k.Masp == Masp);
            if (sp != null)
            {
                _db.Sanphams.Remove(sp);
                _db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        // hàm tìm kiếm
        public List<Sanpham> TimKiem(string searchMaSp, string searchTenSp, string searchMaLoai)
        {
            var query = _db.Sanphams.AsQueryable();

            if (!string.IsNullOrEmpty(searchMaSp))
            {
                query = query.Where(k => k.Masp.Contains(searchMaSp));
            }

            if (!string.IsNullOrEmpty(searchTenSp))
            {
                query = query.Where(k => k.Tensp.Contains(searchTenSp));
            }

            if (!string.IsNullOrEmpty(searchMaLoai))
            {
                query = query.Where(k => k.Maloai == searchMaLoai);
            }
            return query.ToList();
        }
    }
}
