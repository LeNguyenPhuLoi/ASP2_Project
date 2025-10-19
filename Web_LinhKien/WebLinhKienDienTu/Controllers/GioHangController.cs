using Microsoft.AspNetCore.Mvc;

namespace WebLinhKienDienTu.Controllers
{
    public class GioHangController : Controller
    {
        public IActionResult GioHang()
        {
            return View();
        }

        public IActionResult ChiTietHoaDon()
        {
            return View();
        }

        public IActionResult LichSuMuaHang()
        {
            return View();
        }
    }
}
