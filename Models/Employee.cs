using System.ComponentModel.DataAnnotations;

namespace MorgueTrackerMVC.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        public string? EmployeeName { get; set; }

    }

}



