using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Models
{
   public class DoctorTimeSlot
    {
        public int? Id { get; set; }
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Name { get; set; }
        public System.TimeSpan ToTime { get; set; }
        public System.TimeSpan FromTime { get; set; }
        public bool IsActive { get; set; }
        public DoctorTimeSlot()
        {
            Appointments = new Collection<Appointment>();
        }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
