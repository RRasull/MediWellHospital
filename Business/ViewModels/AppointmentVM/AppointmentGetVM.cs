using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels.AppointmentVM
{
   public class AppointmentGetVM
    {
        public int? Id { get; set; }
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AppointDate { get; set; }
        public string DoctorComment { get; set; }
        public bool Status { get; set; }

        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}
