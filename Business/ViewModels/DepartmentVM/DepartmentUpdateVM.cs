using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.DepartmentVM
{
   public class DepartmentUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }
    }
}
