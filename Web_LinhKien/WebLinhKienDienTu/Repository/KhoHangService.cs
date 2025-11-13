using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public class KhoHangService : IKhoHangService
    {
        private readonly QllkContext _db;

        public KhoHangService(QllkContext db) 
        {
            _db = db;
        }

        //hàm lấy danh sách kho hàng
        public List<Khohang> LayDanhSachKhoHang()
        {
            List<Khohang> list = new List<Khohang>();
            list = _db.Khohangs.ToList();
            return list;
        }

        //hàm tìm kho hàng theo mã kho
        public List<Khohang> TimKhoHangTheoMaKho(string makho)
        {
            List<Khohang> list = new List<Khohang>();
            list = _db.Khohangs
                .Where(x => x.Makho.StartsWith(makho))
                .ToList();
            return list;
        }

        //hàm tìm kho hàng theo tên kho
        public List<Khohang> TimKhoHangTheoTenKho(string tenkho)
        {
            List<Khohang> list = new List<Khohang>();
            list = _db.Khohangs
                .Where(x => x.Tenkho.Contains(tenkho))
                .ToList();
            return list;
        }

        //lấy danh sách nhân viên
        public IEnumerable<SelectListItem> GetDanhSachNhanVien()
        {
            var nhanviens = _db.Nhanviens
                .Select(nv => new SelectListItem
                {
                    Text = nv.Tennv,
                    Value = nv.Manv
                })
                .ToList();

            return nhanviens;
        }

        //hàm thêm kho hàng
        public void AddKhoHang(string Tenkho, string Diachi, string Manv, string Soluongloaihang)
        {
            string Makho;
            int soluongmoi = _db.Khohangs.Count() + 1;
            Makho = "KHO" + soluongmoi.ToString("D2");

            var kho = new Khohang
            {
                Makho = Makho,
                Tenkho = Tenkho,
                Diachikho = Diachi,
                Manv = Manv,
                Soluongloaihang = Soluongloaihang
            };
            _db.Khohangs.Add(kho);
            _db.SaveChanges();
        }

        //hàm sửa kho hàng
        public bool EditKhoHang(string Makho, string Tenkho, string Diachi, string Manv, string Soluongloaihang)
        {
            bool flag = false;
            var kho = _db.Khohangs.FirstOrDefault(k => k.Makho == Makho);
            if(kho != null)
            {
                kho.Tenkho = Tenkho;
                kho.Diachikho = Diachi;
                kho.Manv = Manv;
                kho.Soluongloaihang = Soluongloaihang;
                _db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        //hàm xóa kho hàng
        public bool DeleteKhoHang(string Makho)
        {
            bool flag = false;
            var kho = _db.Khohangs.FirstOrDefault(k => k.Makho == Makho);
            if (kho != null)
            {
                _db.Khohangs.Remove(kho);
                _db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        //
        public List<Khohang> TimKiem(string searchMaKho, string searchTenKho)
        {
            var query = _db.Khohangs.AsQueryable();

            if (!string.IsNullOrEmpty(searchMaKho))
            {
                query = query.Where(k => k.Makho.Contains(searchMaKho));
            }

            if (!string.IsNullOrEmpty(searchTenKho))
            {
                query = query.Where(k => k.Tenkho.Contains(searchTenKho));
            }
            return query.ToList();
        }
    }
}
