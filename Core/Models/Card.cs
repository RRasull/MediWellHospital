using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
   public class Card
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsDeleted { get; set; }
    }
}
