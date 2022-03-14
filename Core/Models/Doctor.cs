using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Models
{
   public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public decimal Phone { get; set; }
        public bool IsAvailable { get; set; }
        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

        public string Image { get; set; }
        public IFormFile Photo { get; set; }
        public bool IsDeleted { get; set; }



    }
}
