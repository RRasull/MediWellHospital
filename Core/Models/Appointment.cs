using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
   public class Appointment
    {
        public int? Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AppointDate { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        [Required]
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        public string PatientMessage { get; set; }
        [Required]

        public string PatientPhone { get; set; }

        [Required]
        public string PatientUsername { get; set; }

        [Required]
        [EmailAddress]
        public string PatientEmail { get; set; }

        public string DoctorName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
