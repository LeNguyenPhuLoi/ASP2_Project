using System;
using WebLinhKienDienTu.Models;
using WebLinhKienDienTu.ViewModels;

namespace WebLinhKienDienTu.Repository
{
    public class GioHangService : IGioHangService
    {
        private readonly QllkContext _db;

        public GioHangService(QllkContext db) 
        {
            _db = db;
        }

        //hàm lấy mã kho theo mã sản phẩm
        public string LayMaKhoTheoMaSP(string masp)
        {
            var kho = _db.KhoSanphams.FirstOrDefault(sp => sp.Masp == masp);
            return kho != null ? kho.Makho : "";
        }

        //hàm lấy mã khách hàng theo email
        public string LayMaKHTheoEmail(string email)
        {
            var kh = _db.Khachhangs.FirstOrDefault(k => k.Email == email);
            return kh != null ? kh.Makh : "";
        }

        //hàm lấy giá sản phẩm theo mã sản phẩm
        public decimal LayGiaSpTheoMaSP(string masp)
        {
            decimal gia = Convert.ToDecimal((from sp in _db.Sanphams
                          where sp.Masp == masp
                          select sp.Dongia).FirstOrDefault());
            return gia;
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

        //hàm thêm hóa đơn
        public void AddHoaDon(string Mahoadon,string Makh, decimal Tongtien, string Trangthai)
        {
            var hoadon = new Hoadon
            {
                Mahd = Mahoadon,
                Makh = Makh,
                Ngaylap = DateTime.Now.Date,
                Manv = null,
                Tongtien = Convert.ToDecimal(Tongtien),
                Trangthai = Trangthai
            };
            _db.Hoadons.Add(hoadon);
            _db.SaveChanges();
        }

        //hàm thêm chi tiết hóa đon
        public void AddChiTietHoaDon(string mahd, string masp, int soluong, decimal dongia)
        {
            string makho = LayMaKhoTheoMaSP(masp);
            Chitiethoadon cthd = new Chitiethoadon()
            {
                Mahd = mahd,
                Masp = masp,
                Makho = makho,
                Soluong = soluong,
                Dongia = dongia,
                Thanhtien = soluong * dongia
            };

            _db.Chitiethoadons.Add(cthd);
            _db.SaveChanges();
        }

        //hàm thêm giỏ hàng
        public bool AddGioHang(string email, string masp, int soluong)
        {
            string makh = LayMaKHTheoEmail(email);

            var exist = _db.Giohangs.SingleOrDefault(gh => gh.Masp == masp && gh.Makh == makh);
            if (exist == null)
            {
                string lastId = _db.Hoadons
                                .OrderByDescending(h => h.Mahd)
                                .Select(h => h.Mahd)
                                .FirstOrDefault();
                int number = 0;
                if (!string.IsNullOrEmpty(lastId))
                {
                    number = int.Parse(lastId.Substring(2));  // Bỏ "HD"
                }
                string Mahoadon = "HD" + (number + 1).ToString("D3");

                string Trangthai = "Chưa thanh toán"; decimal Tongtien = LayGiaSpTheoMaSP(masp) * soluong;

                AddHoaDon(Mahoadon, makh, Tongtien, Trangthai);
                AddChiTietHoaDon(Mahoadon, masp, soluong, LayGiaSpTheoMaSP(masp));

                Giohang gh = new Giohang()
                {
                    Makh = makh,
                    Masp = masp,
                    Soluong = soluong,
                    Mahd = Mahoadon
                };

                _db.Giohangs.Add(gh);
                _db.SaveChanges();
                return true;
            }
            else
            { 
                exist.Soluong += soluong;
                var chitiet = _db.Chitiethoadons.Single(ct => ct.Mahd == exist.Mahd);
                chitiet.Soluong = exist.Soluong;
                chitiet.Thanhtien = chitiet.Dongia * exist.Soluong;
               
                _db.SaveChanges();
                return true;
            }    
        }

        //hàm xóa giỏ hàng theo mã hóa đơn
        public void DeleDeleteHoaDonTheoMahd(string mahoadon)
        {
            _db.Chitiethoadons.Remove(_db.Chitiethoadons.Single(x => x.Mahd == mahoadon));
            _db.Giohangs.Remove(_db.Giohangs.Single(x => x.Mahd == mahoadon));
            _db.Hoadons.Remove(_db.Hoadons.Single(x => x.Mahd == mahoadon));
            _db.SaveChanges();
        }

        //hàm xóa toàn bộ giỏ hàng
        public void DeleteAllGioHang(string email)
        {
            string makh = LayMaKHTheoEmail(email);

            var exist = _db.Giohangs.Where(gh => gh.Makh == makh);
            foreach( var gh in exist)
            {
                _db.Chitiethoadons.Remove(_db.Chitiethoadons.Single(x => x.Mahd == gh.Mahd));
                _db.Giohangs.Remove(_db.Giohangs.Single(x => x.Mahd == gh.Mahd));
                _db.Hoadons.Remove(_db.Hoadons.Single(x => x.Mahd == gh.Mahd));
            }
            _db.SaveChanges();
        }
    }
}
