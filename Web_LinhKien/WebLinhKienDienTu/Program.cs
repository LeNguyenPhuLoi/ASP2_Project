using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebLinhKienDienTu.Data;
using WebLinhKienDienTu.Models;
using WebLinhKienDienTu.Repository;
using static System.Net.Mime.MediaTypeNames;

namespace WebLinhKienDienTu
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Connection
            AutoConnectSql autoConnectSql = new AutoConnectSql();
            var connectionString = autoConnectSql.GetConnection();

            if(connectionString == null)
            {
                builder.Logging.AddConsole();
                Console.WriteLine("Không thể kết nối SQL Server. Ứng dụng sẽ không khởi chạy.");
                throw new Exception("Không kết nối được SQL Server.");
            }

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<QllkContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // cấu hình password/lockout nếu muốn
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ISanPhamService, SanPhamService>();
            var app = builder.Build();
            //using (var scope = app.Services.CreateScope())
            //{
            //    var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            //    // Tạo roles nếu chưa có
            //    string[] roles = new[] { "Admin", "User" };
            //    foreach (var r in roles)
            //        if (!await roleMgr.RoleExistsAsync(r)) await roleMgr.CreateAsync(new IdentityRole(r));

            //    // Tạo admin user nếu chưa có
            //    var adminEmail = "admin@local.test";
            //    var admin = await userMgr.FindByEmailAsync(adminEmail);
            //    if (admin == null)
            //    {
            //        admin = new ApplicationUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
            //        await userMgr.CreateAsync(admin, "Admin@123"); // mật khẩu phải đủ mạnh theo policy
            //        await userMgr.AddToRoleAsync(admin, "Admin");
            //    }
            //}


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
