using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.ViewModels.AppointmentVM
{
   public class AppointCreateVM
    {

        public string Phone { get; set; }


        public int DoctorId { get; set; }

        public List<Doctor> Doctors { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AppointDate { get; set; }

        public string Message { get; set; }

        public User User { get; set; }
    }
}
