using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.PatientVM
{
   public class PatientGetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Phone { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }

        public string Height { get; set; }
        public string Weight { get; set; }
        public string Image { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
