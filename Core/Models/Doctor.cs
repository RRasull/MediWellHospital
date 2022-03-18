using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Models
{
   public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public string Education { get; set; }
        public string WorkingHours { get; set; }
        public double Fees { get; set; }
        public string Splztion { get; set; }

        public Gender Gender { get; set; }




        public int? DepartamentId { get; set; }
        public Departament Departament { get; set; }


        public string Image { get; set; }
        public IFormFile Photo { get; set; }
        public bool IsDeleted { get; set; }

        public Doctor()
        {
            Appointments = new Collection<Appointment>();
        }
        public ICollection<Appointment> Appointments { get; set; }



    }
}
