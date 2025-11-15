using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLinhKienDienTu.Models;
using WebLinhKienDienTu.Repository;

namespace WebLinhKienDienTu.Controllers
{
    public class AdminController : Controller
    {
        public readonly ILoaiSPService _loaiSPService;
        public readonly ISanPhamService _sanphamservice;
        public readonly IHoaDonService _hoadonservice;
        public readonly IKhoSPService _khoSPService;
        public readonly IKhoHangService _khohangservice;

        public AdminController(ILoaiSPService loaiSanPhamService, ISanPhamService sanphamservice, IHoaDonService hoadonservice, IKhoSPService khoSanPhamService, IKhoHangService khohangservice)
        {
            _loaiSPService = loaiSanPhamService;
            _sanphamservice = sanphamservice;
            _hoadonservice = hoadonservice;
            _khoSPService = khoSanPhamService;
            _khohangservice = khohangservice;
        }

        public IActionResult QuanLyHoaDon(int page = 1)
        {
            int pageSize = 5; // Số dòng mỗi trang

            // Lấy toàn bộ danh sách
            var danhsach = _hoadonservice.LayDanhSachHoaDon()
                                          .OrderBy(k => k.Mahd);

            // Tính toán phân trang
            var data = danhsach.Skip((page - 1) * pageSize)
                               .Take(pageSize)
                               .ToList();

            // Gửi thông tin phân trang sang View
            ViewBag.Page = page;
            ViewBag.TotalPage = (int)Math.Ceiling((double)danhsach.Count() / pageSize);

            IEnumerable<SelectListItem> khachHangs = _hoadonservice.GetDanhSachKhachHang();
            ViewBag.Makh = khachHangs;

            IEnumerable<SelectListItem> nhanviens = _hoadonservice.GetDanhSachNhanVien();
            ViewBag.Manv = nhanviens;

            return View(data);
        }

        [HttpPost]
        public IActionResult QuanLyHoaDon(string searchMa, string searchKhachHang, string searchTrangThai)
        {
            IEnumerable<SelectListItem> khachHangs = _hoadonservice.GetDanhSachKhachHang();
            ViewBag.Makh = khachHangs;

            IEnumerable<SelectListItem> nhanviens = _hoadonservice.GetDanhSachNhanVien();
            ViewBag.Manv = nhanviens;

            var model = _hoadonservice.TimKiem(searchMa, searchKhachHang, searchTrangThai);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddHoaDon(string Makh,string Manv, string Tongtien, string Trangthai)
        {
            _hoadonservice.AddHoaDon(Makh, Manv, Tongtien, Trangthai);
            return RedirectToAction("QuanLyHoaDon");
        }

        [HttpPost]
        public IActionResult EditHoaDon(string Mahoadon, string Makh, string Ngaylap, string Manv, string Tongtien, string Trangthai)
        {
            _hoadonservice.EditHoaDon(Mahoadon, Makh, Ngaylap, Manv, Tongtien, Trangthai);
            return RedirectToAction("QuanLyHoaDon");
        }

        [HttpPost]
        public IActionResult DeleteHoaDon(string Mahoadon)
        {
            _hoadonservice.DeleteHoaDon(Mahoadon);
            return RedirectToAction("QuanLyHoaDon");
        }

        public IActionResult QuanLyKhoSP(int page = 1)
        {
            int pageSize = 5; // Số dòng mỗi trang

            // Lấy toàn bộ danh sách
            var danhsach = _khoSPService.LayDanhSachKhoSanPham()
                                             .OrderBy(k => k.Makho);

            // Tính toán phân trang
            var data = danhsach.Skip((page - 1) * pageSize)
                               .Take(pageSize)
                               .ToList();

            // Gửi thông tin phân trang sang View
            ViewBag.Page = page;
            ViewBag.TotalPage = (int)Math.Ceiling((double)danhsach.Count() / pageSize);

            // Truyền danh sách kho hàng vào View
            ViewBag.DanhSachKho = _khohangservice.LayDanhSachKhoHang();
            ViewBag.DanhSachSP = _sanphamservice.GetAllSP();

            // **Giữ ô tìm kiếm trống ban đầu**
            ViewBag.searchMaSp = "";
            ViewBag.searchMaKho = "";

            return View(data);
        }

        [HttpPost]
        public IActionResult QuanLyKhoSP(string searchMaSp, string searchMaKho)
        {
            var model = _khoSPService.TimKiem(searchMaSp, searchMaKho);

            // Truyền danh sách kho hàng vào View
            ViewBag.DanhSachKho = _khohangservice.LayDanhSachKhoHang();
            ViewBag.DanhSachSP = _sanphamservice.GetAllSP();

            // Giữ lại giá trị đã nhập/tìm
            ViewBag.searchMaSp = searchMaSp;
            ViewBag.searchMaKho = searchMaKho;

            return View(model);
        }

        [HttpPost]
        public IActionResult AddKhoSanPham(string makho, string Masp, int Soluongnhap)
        {
            _khoSPService.AddKhoSanPham(makho, Masp, Soluongnhap);
            return RedirectToAction("QuanLyKhoSP");
        }

        [HttpPost]
        public IActionResult EditKhoSanPham(string makho, string Masp, DateTime Ngaynhap, int Soluongnhap)
        {
            _khoSPService.EditKhoSanPham(makho, Masp, Ngaynhap, Soluongnhap);
            return RedirectToAction("QuanLyKhoSP");
        }

        [HttpPost]
        public IActionResult DeleteKhoSanPham(string makho)
        {
            _khoSPService.DeleteKhoSanPham(makho);
            return RedirectToAction("QuanLyKhoSP");
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

            // **Giữ ô tìm kiếm trống ban đầu**
            ViewBag.searchMaSp = "";
            ViewBag.searchTenSp = "";
            ViewBag.searchLoai = "";

            return View(data);
        }

        [HttpPost]
        public IActionResult QuanLySP(string searchMaSp, string searchTenSp, string searchLoai)
        {
            // Gọi đúng service (tham số thứ ba là mã loại)
            var model = _sanphamservice.TimKiem(searchMaSp, searchTenSp, searchLoai);

            // Nạp lại danh sách loại cho dropdown
            ViewBag.DanhSachLoai = _loaiSPService.LayDanhSachLoaiSanPham();

            // Giữ lại giá trị đã nhập/tìm
            ViewBag.searchMaSp = searchMaSp;
            ViewBag.searchTenSp = searchTenSp;
            ViewBag.searchLoai = searchLoai;

            // Không cần phân trang ở kết quả tìm kiếm
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
