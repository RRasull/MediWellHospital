using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels.PatientVM
{
   public class PatientUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }


        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }


        public string Phone { get; set; }


        public string Address { get; set; }


        public string EmailAddress { get; set; }


        public string Description { get; set; }



        public string Height { get; set; }


        public string Weight { get; set; }



        public IFormFile Photo { get; set; }

        //Patient identity

        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
