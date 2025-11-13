using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public class HoaDonService : IHoaDonService
    {
        private readonly QllkContext _db;

        public HoaDonService(QllkContext db)
        {
            _db = db;
        }

        //hàm lấy danh sách hóa đơn
        public List<Hoadon> LayDanhSachHoaDon()
        {
            List<Hoadon> list = new List<Hoadon>();
            list = _db.Hoadons.ToList();
            return list;
        }

        //lấy danh sách khách hàng
        public IEnumerable<SelectListItem> GetDanhSachKhachHang()
        {
            var khachHangs = _db.Khachhangs
                .Select(kh => new SelectListItem
                {
                    Text = kh.Tenkh,
                    Value = kh.Makh
                })
                .ToList();

            return khachHangs;
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

        //hàm thêm hóa đơn
        public void AddHoaDon(string Makh, string Manv, string Tongtien, string Trangthai)
        {
            string Mahoadon;
            int soluongmoi = _db.Hoadons.Count() + 1;
            Mahoadon = "HD" + soluongmoi.ToString("D3");

            var hoadon = new Hoadon
            {
               Mahd = Mahoadon,
               Makh = Makh,
               Ngaylap = DateTime.Now.Date,
               Manv = Manv,
               Tongtien = Convert.ToDecimal(Tongtien),
               Trangthai = Trangthai
            };
            _db.Hoadons.Add(hoadon);
            _db.SaveChanges();
        }

        //hàm sửa hóa đơn
        public bool EditHoaDon(string Mahoadon, string Makh, string Ngaylap, string Manv, string Tongtien, string Trangthai)
        {
            bool flag = false;
            var hoadon = _db.Hoadons.FirstOrDefault(k => k.Mahd == Mahoadon);
            if (hoadon != null)
            {
                hoadon.Makh = Makh;
                hoadon.Ngaylap = Convert.ToDateTime(Ngaylap);
                hoadon.Manv = Manv;
                hoadon.Tongtien = Convert.ToDecimal(Tongtien);
                hoadon.Trangthai = Trangthai;
                _db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        //hàm xóa hóa đơn
        public bool DeleteHoaDon(string Mahoadon)
        {
            bool flag = false;
            var hd = _db.Hoadons.FirstOrDefault(k => k.Mahd == Mahoadon);
            if (hd != null)
            {
                _db.Hoadons.Remove(hd);
                _db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        //hàm tìm kiếm
        public List<Hoadon> TimKiem(string searchMa, string searchKhachHang, string searchTrangThai)
        {
            var query = _db.Hoadons.AsQueryable();

            if (!string.IsNullOrEmpty(searchMa))
            {
                query = query.Where(k => k.Mahd.Contains(searchMa));
            }

            if (!string.IsNullOrEmpty(searchKhachHang))
            {
                query = query.Where(k => k.Makh.Contains(searchKhachHang));
            }

            if (!string.IsNullOrEmpty(searchTrangThai))
            {
                query = query.Where(k => k.Trangthai.Contains(searchTrangThai));
            }

            return query.ToList();
        }
    }
}
