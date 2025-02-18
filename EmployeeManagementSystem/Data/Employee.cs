using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string BasicSalary { get; set; }
        public string? OverTime { get; set; }
        public string NetSalary { get; set; }

    }
}
