using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
   public class Departament
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

        public string Image { get; set; }
        public IFormFile Photo { get; set; }


        public bool IsDeleted { get; set; }


    }
}
