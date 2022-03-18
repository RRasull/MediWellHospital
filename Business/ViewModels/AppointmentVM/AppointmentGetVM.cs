using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.AppointmentVM
{
   public class AppointmentGetVM
    {
        public int? Id { get; set; }
        public List<DateTime> AppointDate { get; set; }
        public string DoctorComment { get; set; }
        public bool Status { get; set; }

        public int Patient { get; set; }
        public IEnumerable<Patient> Patients { get; set; }

        public int Doctor { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
