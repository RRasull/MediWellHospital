using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels.PatientCommentVM
{
   public class PatientCommentCreateVM
    {
        [Required]
        public string Comment { get; set; }
        [Required]
        public IFormFile Photo { get; set; }

        public string Image { get; set; }
        [Required,MaxLength(255)]
        public string Fullname { get; set; }
        [Required,MaxLength(50)]
        public string Profession { get; set; }
    }
}
