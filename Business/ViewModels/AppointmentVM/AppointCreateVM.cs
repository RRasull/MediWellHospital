using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels.AppointmentVM
{
   public class AppointCreateVM
    {
        private DateTime _releaseDate = DateTime.MinValue;
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public string Phone { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public List<Doctor> Doctors { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AppointDate
        {
            get
            {
                return (_releaseDate == DateTime.MinValue) ? DateTime.Now : _releaseDate;
            }

            set
            {
                _releaseDate = value;
            }
        }

        [Required]
        public int DepartamentId { get; set; }

        public List<Departament> Departaments { get; set; }

        public string Message { get; set; }
    }
}
