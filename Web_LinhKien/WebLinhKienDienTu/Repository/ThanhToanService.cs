using WebLinhKienDienTu.Models;
using WebLinhKienDienTu.ViewModels;

namespace WebLinhKienDienTu.Repository
{
    public class ThanhToanService: IThanhToanService
    {
        private readonly QllkContext _db;

        public ThanhToanService(QllkContext db)
        {
            _db = db;
        }

        //hàm lấy mã khách hàng theo email
        public string LayMaKHTheoEmail(string email)
        {
            var kh = _db.Khachhangs.FirstOrDefault(k => k.Email == email);
            return kh != null ? kh.Makh : "";
        }

        //hàm lấy danh sách giỏ hàng theo makh
        public List<GioHangViewModel> LayDanhSachGioHangTheoMaKH(string email)
        {
            string makh = LayMaKHTheoEmail(email);
            var ds = (from gh in _db.Giohangs
                      join sp in _db.Sanphams
                        on gh.Masp equals sp.Masp
                      where gh.Makh == makh
                      select new GioHangViewModel
                      {
                          Masp = sp.Masp,
                          Tensp = sp.Tensp,
                          Soluong = Convert.ToInt32(gh.Soluong),
                          Gia = Convert.ToDecimal(sp.Dongia),
                          Mahd = gh.Mahd
                      }).ToList();
            return ds;
        }
    }
}
