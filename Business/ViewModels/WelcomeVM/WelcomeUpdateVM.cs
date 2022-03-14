using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.WelcomeVM
{
   public class WelcomeUpdateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string WhyUs { get; set; }
    }
}
