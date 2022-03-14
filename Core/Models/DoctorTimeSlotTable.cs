using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
   public class DoctorTimeSlotTable
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Name { get; set; }
        public System.TimeSpan ToTime { get; set; }
        public System.TimeSpan FromTime { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
