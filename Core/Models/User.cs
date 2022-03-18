using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
   public class User : IdentityUser
    {
        public string Fullname { get; set; }
        public bool IsActivated { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
