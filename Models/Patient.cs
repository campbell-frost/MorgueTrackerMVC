
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MorgueTrackerMVC.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        public string? PatientName { get; set; }

        public string? LocationInMorgue { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime PickedUpDate { get; set; }

        // Navigation property
        public ICollection<Release>? Releases { get; set; }
    }


}

