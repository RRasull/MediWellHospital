using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class HomeVM
    {
        public Welcome Welcome { get; set; }
        public IEnumerable<Card> Cards { get; set; }
        public Dictionary<string, string> Setting { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public List<Departament> Departaments { get; set; }


    }
}
