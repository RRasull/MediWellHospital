using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels.DoctorVM
{
   public class DoctorUpdateVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Education { get; set; }
        public string WorkingHours { get; set; }
        public double Fees { get; set; }
        public string Splztion { get; set; }
        public Gender Gender { get; set; }
        public int? DepartamentId { get; set; }
        public List<Departament> AllDepartaments { get; set; }
        public Departament Department { get; set; }

        public string Image { get; set; }
        public IFormFile Photo { get; set; }


        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
