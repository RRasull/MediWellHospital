using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
   public class Welcome
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string WhyUs { get; set; }
        public bool IsDeleted { get; set; }
    }
}
