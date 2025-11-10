using Microsoft.AspNetCore.Mvc;
using WebLinhKienDienTu.Repository;

namespace WebLinhKienDienTu.Controllers
{
    public class KhoSPController : Controller
    {
        public readonly IKhoSPService _khoSPService;

        public KhoSPController(IKhoSPService khoSanPhamService)
        {
            _khoSPService = khoSanPhamService;
        }

        public IActionResult KhoSanPham(int page = 1)
        {
            int pageSize = 5; // Số dòng mỗi trang

            // Lấy toàn bộ danh sách
            var danhsach = _khoSPService.LayDanhSachKhoSanPham()
                                             .OrderBy(k => k.Stt);

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
        public IActionResult AddKhoSanPham(int Stt, string Masp, DateTime Ngaynhap, int Soluongnhap)
        {
            _khoSPService.AddKhoSanPham(Stt, Masp, Ngaynhap, Soluongnhap);
            return RedirectToAction("KhoSanPham");
        }

        [HttpPost]
        public IActionResult EditKhoSanPham(int Stt, string Masp, DateTime Ngaynhap, int Soluongnhap)
        {
            _khoSPService.EditKhoSanPham(Stt, Masp, Ngaynhap, Soluongnhap);
            return RedirectToAction("KhoSanPham");
        }

        [HttpPost]
        public IActionResult DeleteKhoSanPham(int Stt)
        {
            _khoSPService.DeleteKhoSanPham(Stt);
            return RedirectToAction("KhoSanPham");
        }

        [HttpPost]
        public IActionResult KhoSanPham(string searchMaSP)
        {
            var model = _khoSPService.TimKiem(searchMaSP);
            return View(model);
        }
    }
}
