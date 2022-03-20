using Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.ViewModels.AppointmentVM
{
   public class AppointmentGetVM
    {
        public int? Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AppointDate { get; set; }
        public string PatientPhone { get; set; }
        public string PatientMessage{ get; set; }

        public string PatientUserName { get; set; }
        public string PatientEmail { get; set; }
        public string DoctorName { get; set; }


        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}
