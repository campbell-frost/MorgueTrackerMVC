
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MorgueTrackerMVC.Models
{

    public class Release
    {
        [Key]
        public int ReleaseID { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? FuneralHome { get; set; }
        public string? FuneralHomeEmployee { get; set; }
        public DateTime PickedUpDate { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }

        [ForeignKey("InEmployee")]
        public int InEmployeeID { get; set; }

        [ForeignKey("OutEmployee")]
        public int OutEmployeeID { get; set; }
        
        // Navigation properties
        public Patient? Patient { get; set; }
        public Employee? InEmployee { get; set; }
        public Employee? OutEmployee { get; set; }
    }

}
