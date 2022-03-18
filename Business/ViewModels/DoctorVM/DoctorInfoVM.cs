using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.DoctorVM
{
   public class DoctorInfoVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Surname { get; set; }
        public string  Splztn { get; set; }
        public string WorkingHours { get; set; }
        public string EmailAdress { get; set; }
        public string Education { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
