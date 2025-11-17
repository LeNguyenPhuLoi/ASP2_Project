using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebLinhKienDienTu.Data;
using WebLinhKienDienTu.Models;
using WebLinhKienDienTu.Repository;

namespace WebLinhKienDienTu
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<QllkContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // cấu hình password/lockout nếu muốn
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ISanPhamService, SanPhamService>();
            builder.Services.AddScoped<ILoaiSPService, LoaiSPService>();
            builder.Services.AddScoped<IKhoHangService, KhoHangService>();
            builder.Services.AddScoped<IHoaDonService, HoaDonService>();
            builder.Services.AddScoped<IChiTietHoaDonService, ChiTietHoaDonService>();
            builder.Services.AddScoped<IKhoSPService, KhoSPService>();
            builder.Services.AddScoped<IGioHangService, GioHangService>();
            builder.Services.AddScoped<ILichSuMuaHangService, LichSuMuaHangService>();
            builder.Services.AddScoped<IKhachHangService, KhachHangService>();
            builder.Services.AddScoped<INhanVienService, NhanVienService>();
            builder.Services.AddScoped<IThanhToanService, ThanhToanService>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var db = scope.ServiceProvider.GetRequiredService<QllkContext>();

                string adminEmail = "admin@local.test";
                string password = "Admin@123";

                // Tạo roles nếu chưa có
                string[] roles = new[] { "Admin", "User" };
                foreach (var r in roles)
                    if (!await roleMgr.RoleExistsAsync(r)) await roleMgr.CreateAsync(new IdentityRole(r));

                // ===== 2. Tạo USER trong Identity nếu chưa có =====
                var admin = await userMgr.FindByEmailAsync(adminEmail);

                if (admin == null)
                {
                    admin = new ApplicationUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true
                    };

                    await userMgr.CreateAsync(admin, password);
                    await userMgr.AddToRoleAsync(admin, "Admin");
                }

                // ===== 3. Tạo tài khoản trong bảng TAIKHOAN =====
                if (!db.Taikhoans.Any(x => x.Email == adminEmail))
                {
                    var tk = new Taikhoan
                    {
                        Email = adminEmail,
                        Pass = admin.PasswordHash,   // lưu HASH
                        Quyen = "Admin",
                        Trangthai = "Active"
                    };

                    db.Taikhoans.Add(tk);
                    await db.SaveChangesAsync();
                }

                // ===== 4. Tạo nhân viên trong bảng NHANVIEN =====
                if (!db.Nhanviens.Any(x => x.Email == adminEmail))
                {
                    var nv = new Nhanvien
                    {
                        Manv = "NV002",
                        Tennv = "Quản trị viên",
                        Gioitinh = "Nam",
                        Ngaysinh = DateTime.Parse("1990-01-01"),
                        Chuc = "Admin",
                        Luong = 12000000,
                        Diachi = "Hà Nội",
                        Sdt = "0912345678",
                        Email = adminEmail
                    };

                    db.Nhanviens.Add(nv);
                    await db.SaveChangesAsync();
                }
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
