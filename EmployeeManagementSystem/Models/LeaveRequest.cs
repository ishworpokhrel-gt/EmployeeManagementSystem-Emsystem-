using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    [Table("LeaveRequests")]
    public class LeaveRequest
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Applied By")]
        public string AppliedBy { get; set; }
        [Required]
        [DisplayName("Applied Date")]
        public string AppliedDate { get; set;}
        [Required]
        [DisplayName("Leave From")]
        public string leaveFrom { get; set; }
        [Required]
        [DisplayName("Leave TO Date")]

        public string leaveToDate { get; set;}

        [DisplayName("Final Decision")]

        public string FinalDecision { get; set; } = "Unverified";

        

        

    }
}
