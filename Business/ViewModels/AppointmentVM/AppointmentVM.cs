using Business.ViewModels.DoctorVM;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.ViewModels.AppointmentVM
{
   public class AppointmentVM
    {
        public List<DoctorGetVM> Doctors { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public AppointCreateVM AppointCreateVM { get; set; }
    }
}
