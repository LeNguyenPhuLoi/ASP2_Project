using Microsoft.AspNetCore.Mvc;

namespace LinhKienDienTu.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            ViewBag.Layout = "~/Views/Shared/AdminLayout.cshtml"; // Đảm bảo chỉ định layout cho view này
            return View();
        }
    }
}
