using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.CardVM
{
   public class CardUpdateVM
    {
        public int Id { get; set; }
        public string Icon { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
