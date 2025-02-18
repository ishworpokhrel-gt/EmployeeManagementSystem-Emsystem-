using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class LeaveRequest
    {
        [Key]
        public int ID { get; set; }
        public string AppliedBy { get; set; }
        public string AppliedDate { get; set; }
        public string leaveFrom { get; set; }
        public string leaveToDate { get; set; }
        public string FinalDecision { get; set; } = "Unverified";

    }
}
