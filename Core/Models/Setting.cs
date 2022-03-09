using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public bool IsDeleted { get; set; }
    }
}
