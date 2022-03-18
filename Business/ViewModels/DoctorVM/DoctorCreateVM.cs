using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels.DoctorVM
{
   public class DoctorCreateVM
    {
        [Required,MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Surname { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required, MaxLength(255)]
        public string Address { get; set; }

        [Required, MaxLength(255)]
        public string EmailAddress { get; set; }

        public string Description { get; set; }
        [Required, MaxLength(255)]

        public string Education { get; set; }
        [Required]

        public string WorkingHours { get; set; }
        [Required, MaxLength(255)]

        public double Fees { get; set; }
        [Required, MaxLength(255)]

        public string Splztion { get; set; }
        [Required]

        public Gender Gender { get; set; }
        [Required]

        public int DepartamentId { get; set; }
        [Required]

        public IFormFile Photo { get; set; }

        public List<Departament> Departaments { get; set; }

    }
}
