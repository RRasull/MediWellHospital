using Business.ViewModels.DoctorVM;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels.AppointmentVM
{
   public class AppointmentVM
    {
        public List<DoctorGetVM> Doctors { get; set; }
        public List<Departament> Departaments { get; set; }

        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public AppointCreateVM AppointCreateVM { get; set; }
    }
}
