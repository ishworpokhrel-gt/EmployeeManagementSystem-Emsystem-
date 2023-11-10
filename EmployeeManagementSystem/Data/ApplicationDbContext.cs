using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employeess { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>().HasData(
                new Employee { ID = 1, Name = "Ishwor pokhrel", Address = "Hetauda", Contact = "986550284",NetSalary="10000" ,BasicSalary="15000",OverTime="1000", Email = "pokhrelishwor97@gmail.com" },
                new Employee { ID = 2, Name = "Riyaz Ali", Address = "Rajbiraj", Contact = "98623423", NetSalary = "20000", BasicSalary = "25000", OverTime = "1500", Email = "riyaz97@gmail.com" },
                new Employee { ID = 3, Name = "Samundra", Address = "Palpa", Contact = "9862523425", NetSalary = "25000", BasicSalary = "28000", OverTime = "2000", Email = "sam97@gmail.com" }

                );
            builder.Entity<LeaveRequest>().HasData(

                new LeaveRequest() { ID = 4, AppliedBy = "Ishwor", AppliedDate="november 2",leaveFrom="november 5",leaveToDate="november 10"}
                );


        
        
        }
    }
}
