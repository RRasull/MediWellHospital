using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels.CardVM
{
   public class CardCreateVM
    {
        [Required]
        public string Icon { get; set; }
        [Required]

        public string Title { get; set; }
        [Required]

        public string Description { get; set; }
    }
}
