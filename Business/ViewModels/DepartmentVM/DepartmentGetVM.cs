using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.DepartmentVM
{
   public class DepartmentGetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

    }
}
