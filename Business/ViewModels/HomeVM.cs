using Business.ViewModels.AppointmentVM;
using Business.ViewModels.ContactUsVM;
using Business.ViewModels.DepartmentVM;
using Business.ViewModels.DoctorVM;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class HomeVM
    {
        public Welcome Welcome { get; set; }
        public List<Card> Cards { get; set; }
        public Dictionary<string, string> Setting { get; set; }
        public List<DoctorGetVM> Doctors { get; set; }
        public List<Departament> Departaments { get; set; }

        public AppointCreateVM AppointCreateVM { get; set; }

        public List<ContactUsViewModel> ContactUsVM { get; set; }


    }
}
