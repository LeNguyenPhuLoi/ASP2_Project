using Microsoft.AspNetCore.Mvc;
using WebLinhKienDienTu.Repository;

namespace WebLinhKienDienTu.Controllers
{
    public class AdminController : Controller
    {
        public readonly ILoaiSPService _loaiSPService;
        public readonly ISanPhamService _sanphamservice;

        public AdminController(ILoaiSPService loaiSanPhamService, ISanPhamService sanphamservice)
        {
            _loaiSPService = loaiSanPhamService;
            _sanphamservice = sanphamservice;
        }

        public IActionResult QuanLyHoaDon()
        {
            return View();
        }

        public IActionResult QuanLyKhoSP()
        {
            return View();
        }

        public IActionResult QuanLySP(int page = 1)
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

            // Truyền danh sách loại vào View
            ViewBag.DanhSachLoai = _loaiSPService.LayDanhSachLoaiSanPham();

            return View(data);
        }

        [HttpPost]
        public IActionResult QuanLySP(string searchMaSP, string searchTenSP, string searchMaLoai)
        {
            var model = _sanphamservice.TimKiem(searchMaSP, searchTenSP, searchMaLoai);
            // Giữ lại danh sách loại để hiển thị lại combobox
            ViewBag.DanhSachLoai = _loaiSPService.LayDanhSachLoaiSanPham();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddSanPham(string Tensp, decimal Dongia, string Dvt, string Mota, IFormFile fileHinhAnh, int Soluongton, string Maloai)
        {
            string tenFileAnh = null;

            // Nếu người dùng có chọn file
            if (fileHinhAnh != null && fileHinhAnh.Length > 0)
            {
                // Lấy tên file gốc
                tenFileAnh = Guid.NewGuid().ToString() + Path.GetExtension(fileHinhAnh.FileName);

                // Tạo đường dẫn lưu file vào thư mục wwwroot/images
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", tenFileAnh);

                // Lưu file ảnh lên server
                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    fileHinhAnh.CopyTo(stream);
                }
            }
            _sanphamservice.AddSanPham(Tensp, Dongia, Dvt, Mota, tenFileAnh, Soluongton, Maloai);

            return RedirectToAction("QuanLySP");
        }

        [HttpPost]
        public IActionResult EditSanPham(string Masp, string Tensp, decimal Dongia, string Dvt, string Mota, IFormFile fileHinhAnh, int Soluongton, string Maloai)
        {
            string tenFileAnh = null;

            // Lấy sản phẩm hiện tại
            var sanpham = _sanphamservice.GetSanPhamById(Masp);
            if (sanpham == null)
            {
                // Nếu không tìm thấy -> quay lại trang quản lý
                return RedirectToAction("QuanLySP");
            }

            // Nếu người dùng upload ảnh mới
            if (fileHinhAnh != null && fileHinhAnh.Length > 0)
            {
                // Tạo tên file mới (tránh trùng)
                tenFileAnh = Guid.NewGuid().ToString() + Path.GetExtension(fileHinhAnh.FileName);

                // Đường dẫn lưu file ảnh vào wwwroot/image
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", tenFileAnh);

                // Lưu file ảnh
                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    fileHinhAnh.CopyTo(stream);
                }
            }
            else
            {
                // Nếu không upload ảnh mới -> giữ nguyên ảnh cũ
                tenFileAnh = sanpham.Hinhanh;
            }

            // Cập nhật dữ liệu
            _sanphamservice.EditSanPham(Masp, Tensp, Dongia, Dvt, Mota, tenFileAnh, Soluongton, Maloai);

            return RedirectToAction("QuanLySP");
        }

        [HttpPost]
        public IActionResult DeleteSanPham(string Masp)
        {
            _sanphamservice.DeleteSanPham(Masp);
            return RedirectToAction("QuanLySP");
        }    

        public IActionResult QuanLyLoaiSP(int page = 1)
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
        public IActionResult QuanLyLoaiSP(string searchMaLoai, string searchTenLoai)
        {
            var model = _loaiSPService.TimKiem(searchMaLoai, searchTenLoai);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddLoaiSanPham(string Tenloai, string Mota)
        {
            _loaiSPService.AddLoaiSanPham(Tenloai, Mota);
            return RedirectToAction("QuanLyLoaiSP");
        }

        [HttpPost]
        public IActionResult EditLoaiSanPham(string Maloai, string Tenloai, string Mota)
        {
            _loaiSPService.EditLoaiSanPham(Maloai, Tenloai, Mota);
            return RedirectToAction("QuanLyLoaiSP");
        }

        [HttpPost]
        public IActionResult DeleteLoaiSanPham(string Maloai)
        {
            _loaiSPService.DeleteLoaiSanPham(Maloai);
            return RedirectToAction("QuanLyLoaiSP");
        }

        public IActionResult NhanVien()
        {
            return View();
        }

        public IActionResult TaiKhoan()
        {
            return View();
        }

        public IActionResult LichSuHoatDong()
        {
            return View();
        }

        public IActionResult KhachHang()
        {
            return View();
        }

    }
}
