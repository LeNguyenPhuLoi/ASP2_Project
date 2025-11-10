using Microsoft.AspNetCore.Mvc;
using WebLinhKienDienTu.Repository;

namespace WebLinhKienDienTu.Controllers
{
    public class SanPhamController : Controller
    {
        public readonly ISanPhamService _sanphamservice;

        public SanPhamController(ISanPhamService sanphamservice)
        {
            _sanphamservice = sanphamservice;
        }

        public IActionResult SanPham(int page = 1)
        {
            int pageSize = 5; // Số dòng mỗi trang

            // Lấy toàn bộ danh sách
            var danhsach = _sanphamservice.GetAllSP()
                                          .OrderBy(k => k.Masp);

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
        public IActionResult AddSanPham(string Masp, string Tensp, decimal Dongia, string Dvt, string Mota, string Hinhanh, int Soluongton, string Maloai)
        {
            _sanphamservice.AddSanPham(Masp, Tensp, Dongia, Dvt, Mota, Hinhanh, Soluongton, Maloai);
            return RedirectToAction("SanPham");
        }

        [HttpPost]
        public IActionResult EditSanPham(  string Masp, string Tensp, decimal Dongia, string Dvt, string Mota, string Hinhanh, int Soluongton, string Maloai)
        {
            _sanphamservice.EditSanPham(Masp, Tensp, Dongia, Dvt, Mota, Hinhanh, Soluongton, Maloai);
            return RedirectToAction("SanPham");
        }

        [HttpPost]
        public IActionResult DeleteSanPham(string Masp)
        {
            _sanphamservice.DeleteSanPham(Masp);
            return RedirectToAction("SanPham");
        }

        [HttpPost]
        public IActionResult SanPham(string searchMaSP, string searchTenSP)
        {
            var model = _sanphamservice.TimKiem(searchMaSP, searchTenSP);
            return View(model);
        }
    }
}
