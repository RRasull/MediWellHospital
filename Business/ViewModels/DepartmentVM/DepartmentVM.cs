using Business.ViewModels.AppointmentVM;
using Business.ViewModels.DoctorVM;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.DepartmentVM
{
   public class DepartmentVM
    {
        public List<DoctorGetVM> Doctors { get; set; }
        public List<Departament> Departaments { get; set; }

        public AppointCreateVM AppointCreateVM { get; set; }
    }
}
