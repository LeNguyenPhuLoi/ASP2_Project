using Microsoft.AspNetCore.Identity;

namespace WebLinhKienDienTu.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Bạn có thể thêm thuộc tính mở rộng nếu cần (FullName, DateOfBirth...)
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
    }
}
