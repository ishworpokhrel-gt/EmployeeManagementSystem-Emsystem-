using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Data
{
    [Table("Employeess")]
    public class Employee
    {

        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address{ get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(10)]
        public string Contact{ get; set; }
        public string BasicSalary { get; set; }
        public string? OverTime {  get; set; }
        [Required]
        [DisplayName("Net Salary")]
        public string NetSalary { get; set; }

    }
}
