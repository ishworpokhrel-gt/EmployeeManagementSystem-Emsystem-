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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>().HasData(
                new Employee { ID = 1, Name = "Ishwor pokhrel", Address = "Hetauda", Contact = "986550284",Salary="10000" ,Email = "pokhrelishwor97@gmail.com" },
                new Employee { ID = 2, Name = "Riyaz Ali", Address = "Rajbiraj", Contact = "98623423", Salary = "15000", Email = "riyaz97@gmail.com" },
                new Employee { ID = 3, Name = "Samundra", Address = "Palpa", Contact = "9862523425", Salary = "20000", Email = "sam97@gmail.com" }

                );
        }
    }
}
