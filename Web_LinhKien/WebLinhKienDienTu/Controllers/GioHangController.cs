using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebLinhKienDienTu.Models;
using WebLinhKienDienTu.Repository;

namespace WebLinhKienDienTu.Controllers
{
    public class GioHangController : Controller
    {
        public readonly IChiTietHoaDonService _chiTietHoaDon;
        public readonly IGioHangService _gioHangService;
        private readonly ILichSuMuaHangService _lichSuMuaHangService;
        private readonly IThanhToanService _thanhToanService;

        public GioHangController(IChiTietHoaDonService chiTietHoaDon, IGioHangService gioHangService, ILichSuMuaHangService lichSuMuaHangService, IThanhToanService thanhToanService)
        {
            _chiTietHoaDon = chiTietHoaDon;
            _gioHangService = gioHangService;
            _lichSuMuaHangService = lichSuMuaHangService;
            _thanhToanService = thanhToanService;
        }

        public IActionResult GioHang(string email, int page = 1)
        {
            int pageSize = 5; // Số dòng mỗi trang

            // Lấy toàn bộ danh sách
            var danhsach = _gioHangService.LayDanhSachGioHangTheoMaKH(email)
                                          .OrderBy(k => k.Mahd);

            // Tính toán phân trang
            var data = danhsach.Skip((page - 1) * pageSize)
                               .Take(pageSize)
                               .ToList();

            // Gửi thông tin phân trang sang View
            ViewBag.Page = page;
            ViewBag.TotalPage = (int)Math.Ceiling((double)danhsach.Count() / pageSize);


            return View(data);
        }

        [HttpPost]
        public IActionResult AddGioHang(string email, string masp, int soluong)
        {
            var tt = _gioHangService.AddGioHang(email, masp, soluong);
            return RedirectToAction("GioHang", new { email = email });
        }

        [HttpPost]
        public IActionResult DeleteHoaDon(string mahoadon, string email)
        {
            _gioHangService.DeleDeleteHoaDonTheoMahd(mahoadon);
            return RedirectToAction("GioHang", new { email = email });
        }

        public IActionResult DeleteAllGioHang(string email)
        {
            _gioHangService.DeleteAllGioHang(email);
            return RedirectToAction("GioHang", new { email = email });
        }

        public IActionResult ChiTietHoaDon(string mahd)
        {
            return View(_chiTietHoaDon.LayChiTietHoaDon(mahd));
        }

        public IActionResult LichSuMuaHang(string email, int page = 1)
        {
            int pageSize = 5; // Số dòng mỗi trang

            // Lấy toàn bộ danh sách
            var danhsach = _lichSuMuaHangService.LayDanhSachHoaDonTheoEmail(email)
                                          .OrderBy(k => k.Mahd);

            // Tính toán phân trang
            var data = danhsach.Skip((page - 1) * pageSize)
                               .Take(pageSize)
                               .ToList();

            // Gửi thông tin phân trang sang View
            ViewBag.Page = page;
            ViewBag.TotalPage = (int)Math.Ceiling((double)danhsach.Count() / pageSize);
            return View(data);
        }

        [HttpPost]
        public IActionResult LichSuMuaHang(string searchMa, string searchTrangThai, string searchNgay,string email)
        {
            ViewBag.searchMa = searchMa;
            ViewBag.searchTrangThai = searchTrangThai;
            ViewBag.searchNgay = searchNgay;
            ViewBag.email = email;
            var model = _lichSuMuaHangService.TimKiem(searchMa, searchTrangThai, searchNgay, email);
            return View(model);
        }

        public IActionResult ThanhToan(string email, int page = 1)
        {
            int pageSize = 5; // Số dòng mỗi trang

            // Lấy toàn bộ danh sách
            var danhsach = _gioHangService.LayDanhSachGioHangTheoMaKH(email)
                                          .OrderBy(k => k.Mahd);

            // Tính toán phân trang
            var data = danhsach.Skip((page - 1) * pageSize)
                               .Take(pageSize)
                               .ToList();

            // Gửi thông tin phân trang sang View
            ViewBag.Page = page;
            ViewBag.TotalPage = (int)Math.Ceiling((double)danhsach.Count() / pageSize);


            return View(data);
        }
    }
}
