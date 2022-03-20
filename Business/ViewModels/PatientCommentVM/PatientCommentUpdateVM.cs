using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.PatientCommentVM
{
   public class PatientCommentUpdateVM
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public IFormFile Photo { get; set; }
        public string Image { get; set; }
        public string Fullname { get; set; }
        public string Profession { get; set; }
    }
}
