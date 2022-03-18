using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels.ContactUsVM
{
   public class ContactUsCreateVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }

        public Dictionary<string, string> Setting { get; set; }

    }
}
