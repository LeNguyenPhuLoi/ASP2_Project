using Microsoft.AspNetCore.Mvc;

namespace WebLinhKienDienTu.Controllers
{
    public class KhoHangController : Controller
    {
        public IActionResult KhoHang()
        {
            return View();
        }
    }
}
