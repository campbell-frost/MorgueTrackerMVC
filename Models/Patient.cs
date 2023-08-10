using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MorgueTrackerMVC.Models
{

    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        public string?   PatientName { get; set; }

        [ForeignKey("InEmployee")]
        public int InEmployeeID { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? LocationInMorgue { get; set; }

        // Navigation property
        public Employee? InEmployee { get; set; }
    }

}
