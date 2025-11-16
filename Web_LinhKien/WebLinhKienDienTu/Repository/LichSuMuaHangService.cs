using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public class LichSuMuaHangService : ILichSuMuaHangService
    {
        private readonly QllkContext _db;

        public LichSuMuaHangService(QllkContext db) 
        {
            _db = db;
        }

        //hàm lấy mã khách hàng theo email
        public string LayMaKHTheoEmail(string email)
        {
            var kh = _db.Khachhangs.FirstOrDefault(k => k.Email == email);
            return kh != null ? kh.Makh : "";
        }

        //hàm lấy hóa đơn theo mã khách hàng
        public List<Hoadon> LayDanhSachHoaDonTheoEmail(string email) 
        {
            string makh = LayMaKHTheoEmail(email);
            List<Hoadon> list = new List<Hoadon>();
            list = _db.Hoadons.Where(hd => hd.Makh ==  makh).ToList();
            return list;
        }

        //hàm tìm kiếm
        public List<Hoadon> TimKiem(string searchMa, string searchTrangThai, string searchNgay, string email)
        {
            var query = _db.Hoadons.AsQueryable();

            string makh = LayMaKHTheoEmail(email);
            query = query.Where(k => k.Makh.Contains(makh));

            if (!string.IsNullOrEmpty(searchMa))
            {
                query = query.Where(k => k.Mahd.Contains(searchMa));
            }

            if (!string.IsNullOrEmpty(searchTrangThai))
            {
                query = query.Where(k => k.Trangthai.Contains(searchTrangThai));
            }

            if (!string.IsNullOrEmpty(searchNgay))
            {
                if (DateTime.TryParse(searchNgay, out DateTime parsedDate))
                {
                    query = query.Where(k => k.Ngaylap.HasValue
                                          && k.Ngaylap.Value.Date == parsedDate.Date);
                }
            }

            return query.ToList();
        }
    }
}
