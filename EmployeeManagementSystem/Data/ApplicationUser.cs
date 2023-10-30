using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name {  get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
    }
}
