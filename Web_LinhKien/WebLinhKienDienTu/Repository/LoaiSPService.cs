using Microsoft.EntityFrameworkCore;
using WebLinhKienDienTu.Models;
namespace WebLinhKienDienTu.Repository
{
    public class LoaiSPService : ILoaiSPService
    {
        private readonly QllkContext _db;

        public LoaiSPService(QllkContext db)
        {
            _db = db;
        }

        // hàm lấy danh sách loại sản phẩm
        public List<Loaisanpham> LayDanhSachLoaiSanPham()
        {
            List<Loaisanpham> list = new List<Loaisanpham>();
            list = _db.Loaisanphams.ToList();
            return list;
        }

        // hàm tìm loại sản phẩm theo mã loại
        public List<Loaisanpham> TimLoaiSanPhamTheoMaLoai(string maloai)
        {
            List<Loaisanpham> list = new List<Loaisanpham>();
            list = _db.Loaisanphams
                .Where(x => x.Maloai.StartsWith(maloai))
                .ToList();
            return list;
        }

        // hàm tìm loại sản phẩm theo tên loại
        public List<Loaisanpham> TimLoaiSanPhamTheoTenLoai(string tenloai)
        {
            List<Loaisanpham> list = new List<Loaisanpham>();
            list = _db.Loaisanphams
                .Where(x => x.Tenloai.Contains(tenloai))
                .ToList();
            return list;
        }

        // hàm thêm loại sản phẩm
        public void AddLoaiSanPham(string Tenloai, string Mota)
        {
            string maloai;
            int moi = _db.Loaisanphams.Count() + 1;
            maloai = "LSP" + moi.ToString("D2");

            var loai = new Loaisanpham
            {
                Maloai = maloai,
                Tenloai = Tenloai,
                Mota = Mota
            };
            _db.Loaisanphams.Add(loai);
            _db.SaveChanges();
        }

        // hàm sửa loại sản phẩm
        public bool EditLoaiSanPham(string Maloai, string Tenloai, string Mota)
        {
            bool flag = false;
            var loai = _db.Loaisanphams.FirstOrDefault(k => k.Maloai == Maloai);
            if (loai != null)
            {
                loai.Tenloai = Tenloai;
                loai.Mota = Mota;
                _db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        // hàm xóa loại sản phẩm
        public bool DeleteLoaiSanPham(string Maloai)
        {
            bool flag = false;
            var loai = _db.Loaisanphams.FirstOrDefault(k => k.Maloai == Maloai);
            if (loai != null)
            {
                _db.Loaisanphams.Remove(loai);
                _db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        // hàm tìm kiếm
        public List<Loaisanpham> TimKiem(string searchMaLoai, string searchTenLoai)
        {
            var query = _db.Loaisanphams.AsQueryable();

            if (!string.IsNullOrEmpty(searchMaLoai))
            {
                query = query.Where(k => k.Maloai.Contains(searchMaLoai));
            }

            if (!string.IsNullOrEmpty(searchTenLoai))
            {
                query = query.Where(k => k.Tenloai.Contains(searchTenLoai));
            }
            return query.ToList();
        }
    }
}
