using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
   public class Appointment
    {
        public int? Id { get; set; }
        public DateTime AppointDate { get; set; }
        public string DoctorComment { get; set; }
        public bool Status { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public bool IsChecked { get; set; }

        public bool IsDeleted { get; set; }
    }
}
