using System.ComponentModel.DataAnnotations;

namespace MorgueTrackerMVC.Models
{

    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        public string? EmployeeName { get; set; }

        // Add a role property to distinguish between employee types
        [Required]
        public string? Role { get; set; }
    }

}



