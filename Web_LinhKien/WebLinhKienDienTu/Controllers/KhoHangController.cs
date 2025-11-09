using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLinhKienDienTu.Repository;

namespace WebLinhKienDienTu.Controllers
{
    public class KhoHangController : Controller
    {
        public readonly IKhoHangService _khohangservice;

        public KhoHangController(IKhoHangService khohangservice)
        {
            _khohangservice = khohangservice;
        }

        public IActionResult KhoHang(int page = 1)
        {
            int pageSize = 5; // Số dòng mỗi trang

            // Lấy toàn bộ danh sách
            var danhsach = _khohangservice.LayDanhSachKhoHang()
                                          .OrderBy(k => k.Makho);

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
        public IActionResult AddKhoHang(string Makho, string Tenkho, string Diachi, string Manv, string Soluongloaihang)
        {
            _khohangservice.AddKhoHang(Makho, Tenkho, Diachi, Manv, Soluongloaihang);
            return RedirectToAction("KhoHang");
        }

        [HttpPost]
        public IActionResult EditKhoHang (string Makho, string Tenkho, string Diachi, string Manv, string Soluongloaihang)
        {
            _khohangservice.EditKhoHang(Makho, Tenkho, Diachi, Manv, Soluongloaihang);
            return RedirectToAction("KhoHang");
        }

        [HttpPost]
        public IActionResult DeleteKhoHang(string Makho)
        {
            _khohangservice.DeleteKhoHang(Makho);
            return RedirectToAction("KhoHang");
        }

        [HttpPost]
        public IActionResult KhoHang(string searchMaKho, string searchTenKho)
        {
            var model = _khohangservice.TimKiem(searchMaKho, searchTenKho);
            return View(model);
        }
    }
}
