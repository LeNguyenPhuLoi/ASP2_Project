using Microsoft.AspNetCore.Mvc;
using WebLinhKienDienTu.Repository;

namespace WebLinhKienDienTu.Controllers
{
    public class LoaiSPController : Controller
    {
        public readonly ILoaiSPService _loaiSPService;

        public LoaiSPController(ILoaiSPService loaiSanPhamService)
        {
            _loaiSPService = loaiSanPhamService;
        }

        public IActionResult LoaiSanPham(int page = 1)
        {
            int pageSize = 5; // Số dòng mỗi trang

            // Lấy toàn bộ danh sách
            var danhsach = _loaiSPService.LayDanhSachLoaiSanPham()
                                              .OrderBy(k => k.Maloai);

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
        public IActionResult AddLoaiSanPham(string Maloai, string Tenloai, string Mota)
        {
            _loaiSPService.AddLoaiSanPham(Maloai, Tenloai, Mota);
            return RedirectToAction("LoaiSanPham");
        }

        [HttpPost]
        public IActionResult EditLoaiSanPham(string Maloai, string Tenloai, string Mota)
        {
            _loaiSPService.EditLoaiSanPham(Maloai, Tenloai, Mota);
            return RedirectToAction("LoaiSanPham");
        }

        [HttpPost]
        public IActionResult DeleteLoaiSanPham(string Maloai)
        {
            _loaiSPService.DeleteLoaiSanPham(Maloai);
            return RedirectToAction("LoaiSanPham");
        }

        [HttpPost]
        public IActionResult LoaiSanPham(string searchMaLoai, string searchTenLoai)
        {
            var model = _loaiSPService.TimKiem(searchMaLoai, searchTenLoai);
            return View(model);
        }
    }
}
