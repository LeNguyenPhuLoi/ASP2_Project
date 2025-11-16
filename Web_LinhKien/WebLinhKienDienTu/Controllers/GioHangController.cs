using Microsoft.AspNetCore.Mvc;
using WebLinhKienDienTu.Models;
using WebLinhKienDienTu.Repository;

namespace WebLinhKienDienTu.Controllers
{
    public class GioHangController : Controller
    {
        public readonly IChiTietHoaDonService _chiTietHoaDon;
        public readonly IGioHangService _gioHangService;

        public GioHangController(IChiTietHoaDonService chiTietHoaDon, IGioHangService gioHangService)
        {
            _chiTietHoaDon = chiTietHoaDon;
            _gioHangService = gioHangService;
        }

        public IActionResult GioHang(string email)
        {
            return View(_gioHangService.LayDanhSachGioHangTheoMaKH(email));
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

        public IActionResult LichSuMuaHang()
        {
            return View();
        }
    }
}
