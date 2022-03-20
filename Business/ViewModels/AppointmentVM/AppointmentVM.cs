using Business.ViewModels.DoctorVM;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.AppointmentVM
{
   public class AppointmentVM
    {
        public List<DoctorGetVM> Doctors { get; set; }
        public List<Departament> Departaments { get; set; }

        public AppointCreateVM AppointCreateVM { get; set; }
    }
}
