using Microsoft.AspNetCore.Mvc;

namespace LinhKienDienTu.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
