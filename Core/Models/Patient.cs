using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Models
{
   public class Patient
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateTime { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }


        public ICollection<Appointment> Appointments { get; set; }

        public Patient()
        {
            Appointments = new Collection<Appointment>();

        }
    }
}
