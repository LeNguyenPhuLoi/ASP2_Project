using WebLinhKienDienTu.Models;
using WebLinhKienDienTu.ViewModels;

namespace WebLinhKienDienTu.Repository
{
    public class ChiTietHoaDonService : IChiTietHoaDonService
    {
        private readonly QllkContext _db;

        public ChiTietHoaDonService(QllkContext db)
        {
            _db = db;
        }

        public ChiTietHoaDonViewModel LayChiTietHoaDon(string mahd)
        {
            var chitiet = (from hd in _db.Hoadons
                           join cthd in _db.Chitiethoadons
                               on hd.Mahd equals cthd.Mahd
                           join sp in _db.Sanphams
                               on cthd.Masp equals sp.Masp
                           join kh in _db.Khachhangs
                               on hd.Makh equals kh.Makh
                           join nv in _db.Nhanviens
                               on hd.Manv equals nv.Manv
                           join khosp in _db.KhoSanphams
                               on sp.Masp equals khosp.Masp
                           join kho in _db.Khohangs
                               on khosp.Makho equals kho.Makho
                           where hd.Mahd == mahd
                           select new ChiTietHoaDonViewModel
                           {
                               Mahd = hd.Mahd,
                               Tenkh = kh.Tenkh,
                               Ngaylap = hd.Ngaylap ?? DateTime.MinValue,
                               TenNV = nv.Tennv,
                               Trangthai = hd.Trangthai,
                               Tensp = sp.Tensp,
                               Tenkho = kho.Tenkho,
                               Soluong = cthd.Soluong ?? 0,
                               Dongia = sp.Dongia ?? 0
                           }).FirstOrDefault();

            return chitiet;
        }
    }

}
