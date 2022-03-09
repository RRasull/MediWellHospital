using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.DoctorVM
{
  public  class DoctorCreateUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Phone { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public string Education { get; set; }
        public string WorkingHours { get; set; }

        public string Image { get; set; }
        public IFormFile Photo { get; set; }
    }
}
