using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public class KhachHangService : IKhachHangService
    {

        private readonly QllkContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public KhachHangService(QllkContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        //Lay danh sách Khách Hàng
        public List<Khachhang> LoadDSKhachHang()
        {
            return _db.Khachhangs.ToList();
        }

        public async Task AddCustomer(string tenkh, string sdt, string email, string pass, string diachi)
        {
            // 1. Kiểm tra email đã tồn tại chưa
            if (await _userManager.FindByEmailAsync(email) != null)
            {
                throw new Exception("Email đã tồn tại.");
            }

            // 2. Tạo Identity User
            var applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            var identityResult = await _userManager.CreateAsync(applicationUser, pass);

            if (!identityResult.Succeeded)
            {
                throw new Exception(string.Join("; ", identityResult.Errors.Select(e => e.Description)));
            }

            string makh = GenerateNewMaKh();

            Khachhang newcus = new Khachhang
            {
                Makh = makh,
                Tenkh = tenkh,
                Sdt = sdt,
                Email = email,
                Diachi = diachi,
                Ngaytao = DateTime.Now.Date
            };
            _db.Add(newcus);

            Taikhoan newAcc = new Taikhoan
            {
                Email = email,
                Pass = pass,
                Quyen = "User",
                Trangthai = "Active"
            };
            _db.Add(newAcc);
            _db.SaveChanges();
        }

        public bool EditCustomer(string makh, string tenkh, string sdt, string diachi)
        {
            bool flag = false;
            var cus = _db.Khachhangs.FirstOrDefault(k => k.Makh == makh);
            if (cus != null)
            {
                cus.Tenkh = tenkh;
                cus.Sdt = sdt;
                cus.Diachi = diachi;
                _db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public async Task<bool> DeleteCustomer(string makh)
        {
            // Lấy khách hàng
            var kh = await _db.Khachhangs.FirstOrDefaultAsync(k => k.Makh == makh);
            if (kh == null) return false;

            try
            {
                // Tìm user trong Identity theo Email
                var user = await _userManager.FindByEmailAsync(kh.Email);
                if (user != null)
                {
                    // Xóa tài khoản liên quan trong bảng Taikhoans trước
                    var tk = await _db.Taikhoans.FirstOrDefaultAsync(t => t.Email == user.Email);
                    if (tk != null)
                    {
                        // Xóa khách hàng khỏi bảng Khachhang
                        _db.Khachhangs.Remove(kh);
                        _db.Taikhoans.Remove(tk);
                        await _db.SaveChangesAsync(); // commit xóa Taikhoan trước
                    }

                    // Xóa user trong AspNetUsers
                    var result = await _userManager.DeleteAsync(user);
                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // Có thể log lỗi ở đây nếu cần
                Console.WriteLine($"Lỗi khi xóa khách hàng: {ex.Message}");
                return false;
            }
        }


        //hàm tìm kiếm
        public List<Khachhang> TimKiem(string searchMa, string searchKhachHang)
        {
            var query = _db.Khachhangs.AsQueryable();

            if (!string.IsNullOrEmpty(searchMa))
            {
                query = query.Where(k => k.Makh.Contains(searchMa));
            }

            if (!string.IsNullOrEmpty(searchKhachHang))
            {
                query = query.Where(k => k.Tenkh.Contains(searchKhachHang));
            }

            return query.ToList();
        }

        private string GenerateNewMaKh()
        {
            // Lấy mã khách hàng lớn nhất hiện có
            var lastMaKh = _db.Khachhangs
                            .OrderByDescending(k => k.Makh)
                            .Select(k => k.Makh)
                            .FirstOrDefault();

            int newNumber = 1;

            if (!string.IsNullOrEmpty(lastMaKh))
            {
                // Lấy phần số của mã KH (bỏ "KH")
                if (int.TryParse(lastMaKh.Substring(2), out int lastNumber))
                {
                    newNumber = lastNumber + 1;
                }
            }

            // Tạo mã mới dạng KH0001, KH0002, ...
            string newMaKh = "KH" + newNumber.ToString("D3");

            return newMaKh;
        }
    }
}
