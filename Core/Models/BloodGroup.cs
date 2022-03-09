using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Models
{
   public class BloodGroup
    {
        public BloodGroup()
        {
            Patients = new Collection<Patient>();
        }

        public virtual ICollection<Patient> Patients { get; set; }
        public int? Id { get; set; }
        public string BloodGroup1 { get; set; }
    }
}
