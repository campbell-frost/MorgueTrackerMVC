using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MorgueTrackerMVC.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        public string? EmployeeName { get; set; }

        // Navigation properties
        public ICollection<Release>? InReleases { get; set; }
        public ICollection<Release>? OutReleases { get; set; }
    }

}
