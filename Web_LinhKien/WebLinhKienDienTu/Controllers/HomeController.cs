using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebLinhKienDienTu.Models;
using WebLinhKienDienTu.Repository;

namespace WebLinhKienDienTu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ISanPhamService _sanphamservice;

        public HomeController(ILogger<HomeController> logger, ISanPhamService sanphamservice)
        {
            _logger = logger;
            _sanphamservice = sanphamservice;
        }

        public IActionResult Index()
        {
            var sp = _sanphamservice.GetAllSP();
            return View(sp);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        List<string> pd = new List<string>();

        public IActionResult Detail(int id)
        {
            return View(id);
        }
    }
}
