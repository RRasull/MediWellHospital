using Business.ViewModels.AppointmentVM;
using Business.ViewModels.ContactUsVM;
using Business.ViewModels.DepartmentVM;
using Business.ViewModels.DoctorVM;
using Core;
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

        public ContactUsCreateVM ContactUsVM { get; set; }

        public DoctorInfoVM DoctorInfoVM { get; set; }
        public List<ContactUs> ContactUs { get; set; }
        public List<PatientComment> PatientComments { get; set; }

        public User User { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

    }
}
