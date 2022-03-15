using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.DepartmentVM
{
   public class DepartmentCreateVM
    {
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
}
