using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business.ViewModels.DoctorVM
{
   public class DoctorCreateIdentityVM
    {
        //Doctor Personal
        [Required,MaxLength(255)]
        public string DoctorName { get; set; }
        [Required, MaxLength(255)]

        public string DoctorSurname { get; set; }
        [Required, MaxLength(50)]

        public string DoctorPhone { get; set; }
        [Required, MaxLength(255)]

        public string DoctorAddress { get; set; }
     
        [MaxLength(255)]

        public string Description { get; set; }

        [Required, MaxLength(255)]
        public string DoctorEducation { get; set; }

        [Required]
        public string DoctorWorkingHours { get; set; }
        [Required]

        public double DoctorFees { get; set; }

        [Required, MaxLength(255)]
        public string DoctorSplztion { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required, NotMapped]
        public IFormFile Photo { get; set; }

        [Required]
        public int DepartamentId { get; set; }

        public List<Departament> Departaments { get; set; }

        //Doctor Identity

        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }

        
    }
}
