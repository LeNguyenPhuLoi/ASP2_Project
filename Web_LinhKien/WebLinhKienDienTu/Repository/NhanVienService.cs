using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebLinhKienDienTu.Models;

namespace WebLinhKienDienTu.Repository
{
    public class NhanVienService : INhanVienService
    {
        private readonly QllkContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public NhanVienService(QllkContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public List<Nhanvien> LoadDSNhanVien()
        {
            return _db.Nhanviens.ToList();
        }

        public async Task AddNhanVien(string tennv, string sdt, string gioitinh, string ngaysinh,
                              string chuc, string luong, string email, string pass, string diachi)
        {
            // 1. Kiểm tra email tồn tại
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

            // 4. Gán quyền Admin cho user mới
            await _userManager.AddToRoleAsync(applicationUser, "Admin");

            // 5. Tạo mã nhân viên
            string manv = GenerateNewManv();

            // 6. Lưu thông tin nhân viên
            Nhanvien newcus = new Nhanvien
            {
                Manv = manv,
                Tennv = tennv,
                Sdt = sdt,
                Gioitinh = gioitinh,
                Ngaysinh = DateTime.Parse(ngaysinh),
                Chuc = chuc,
                Luong = decimal.Parse(luong),
                Diachi = diachi,
                Email = email
            };
            _db.Add(newcus);

            // 7. Lưu tài khoản (nếu bạn vẫn cần table Taikhoan riêng)
            Taikhoan newAcc = new Taikhoan
            {
                Email = email,
                Pass = pass,
                Quyen = "Admin", // <--- cập nhật quyền
                Trangthai = "Active"
            };
            _db.Add(newAcc);

            await _db.SaveChangesAsync();
        }


        public bool EditNhanVien(string manv, string tennv, string sdt, string gioitinh, string ngaysinh,
                              string chuc, string luong, string diachi )
        {
            bool flag = false;
            var nv = _db.Nhanviens.FirstOrDefault(k => k.Manv == manv);
            if (nv != null)
            {
               nv.Tennv = tennv;
                nv.Sdt = sdt;
                nv.Gioitinh = gioitinh;
                nv.Chuc = chuc;
                nv.Ngaysinh = DateTime.Parse(ngaysinh);
                nv.Diachi = diachi;
                nv.Luong = decimal.Parse(luong);
                _db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public async Task<bool> DeleteNhanVien(string manv)
        {
            // Lấy nhân viên
            var nv = await _db.Nhanviens.FirstOrDefaultAsync(k => k.Manv == manv);
            if (nv == null) return false;

            try
            {
                // Tìm user trong Identity theo Email
                var user = await _userManager.FindByEmailAsync(nv.Email);
                if (user != null)
                {
                    // Xóa tài khoản liên quan trong bảng Taikhoans trước
                    var tk = await _db.Taikhoans.FirstOrDefaultAsync(t => t.Email == user.Email);
                    if (tk != null)
                    {
                        _db.Taikhoans.Remove(tk);
                        // Xóa nhân viên khỏi bảng Nhanviens
                        _db.Nhanviens.Remove(nv);
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
                // Log lỗi nếu cần
                Console.WriteLine($"Lỗi khi xóa nhân viên: {ex.Message}");
                return false;
            }
        }


        //hàm tìm kiếm
        public List<Nhanvien> TimKiem(string searchMa, string searchTen)
        {
            var query = _db.Nhanviens.AsQueryable();

            if (!string.IsNullOrEmpty(searchMa))
            {
                query = query.Where(k => k.Manv.Contains(searchMa));
            }

            if (!string.IsNullOrEmpty(searchTen))
            {
                query = query.Where(k => k.Tennv.Contains(searchTen));
            }

            return query.ToList();
        }

        private string GenerateNewManv()
        {
            // Lấy mã nhân viên lớn nhất hiện có
            var lastMaKh = _db.Nhanviens
                            .OrderByDescending(k => k.Manv)
                            .Select(k => k.Manv)
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
            string newMaKh = "NV" + newNumber.ToString("D3");

            return newMaKh;
        }

    }
}
