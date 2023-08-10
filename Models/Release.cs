using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MorgueTrackerMVC.Models
{
    public class Release
    {
        [Key]
        public int ReleaseID { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }

        [ForeignKey("OutEmployee")]
        public int OutEmployeeID { get; set; }

        public string? FuneralHome { get; set; }

        public string? FuneralHomeEmployee { get; set; }

        public DateTime PickedUpDate { get; set; }

        // Navigation properties
        public Patient? Patient{ get; set; }
        public Employee? OutEmployee { get; set; }
    }
}
