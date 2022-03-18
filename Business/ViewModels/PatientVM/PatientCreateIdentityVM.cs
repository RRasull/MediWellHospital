using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels.PatientVM
{
   public class PatientCreateIdentityVM
    {
        //Patient Create
        
        [Required,MaxLength(255)]

        public string Name { get; set; }
        [Required, MaxLength(255)]

        public string Surname { get; set; }
        [Required]

        public Gender Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        [Required]

        public decimal Phone { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string EmailAddress { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]


        public string Height { get; set; }
        [Required]

        public string Weight { get; set; }
        
        [Required]

        public IFormFile Photo { get; set; }

        //Patient identity

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
