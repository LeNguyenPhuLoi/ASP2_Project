using Microsoft.AspNetCore.Mvc;
using WebLinhKienDienTu.Repository;

namespace WebLinhKienDienTu.Controllers
{
    public class GioHangController : Controller
    {
        public readonly IChiTietHoaDonService _chiTietHoaDon;

        public GioHangController(IChiTietHoaDonService chiTietHoaDon)
        {
            _chiTietHoaDon = chiTietHoaDon;
        }

        public IActionResult GioHang()
        {
            return View();
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
