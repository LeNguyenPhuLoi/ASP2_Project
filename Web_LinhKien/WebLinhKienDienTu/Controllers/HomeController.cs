using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebLinhKienDienTu.Models;
using WebLinhKienDienTu.Repository;
using X.PagedList;

namespace WebLinhKienDienTu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ISanPhamService _sanphamservice;
        public readonly ILoaiSPService _loaiSPService;

        public HomeController(ILogger<HomeController> logger, ISanPhamService sanphamservice, ILoaiSPService loaiSanPhamService)
        {
            _logger = logger;
            _sanphamservice = sanphamservice;
            _loaiSPService = loaiSanPhamService;
        }

        public IActionResult Index(int? page)
        {
            ViewBag.DanhSachLoai = _loaiSPService.LayDanhSachLoaiSanPham();
            var sp = _sanphamservice.GetAllSP().ToPagedList(page ?? 1, 8);
            return View(sp);
        }

        public IActionResult Privacy()
        {
            ViewBag.DanhSachLoai = _loaiSPService.LayDanhSachLoaiSanPham();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        List<string> pd = new List<string>();

        public IActionResult Detail(string id)
        {
            ViewBag.DanhSachLoai = _loaiSPService.LayDanhSachLoaiSanPham();
            var sp = _sanphamservice.GetSanPhamById(id);
            if (sp == null)
            {
                return NotFound(); // phòng trường hợp id không tồn tại
            }
            return View(sp);
        }

        [HttpPost]
        public IActionResult Search(string searchMaSp, string searchTenSp, string searchLoai, int? page)
        {
            var model = _sanphamservice.TimKiem(searchMaSp, searchTenSp, searchLoai);
            int pageSize = 8;
            int pageNumber = page ?? 1;

            var pagedData = model.ToPagedList(pageNumber, pageSize);

            ViewBag.Page = pageNumber;
            ViewBag.TotalPage = pagedData.PageCount;

            ViewBag.DanhSachLoai = _loaiSPService.LayDanhSachLoaiSanPham();

            ViewBag.searchMaSp = searchMaSp;
            ViewBag.searchTenSp = searchTenSp;
            ViewBag.searchLoai = searchLoai;

            return View("Index", pagedData);
        }
    }
}
