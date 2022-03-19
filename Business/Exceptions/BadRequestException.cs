using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
   public class BadRequestException : FileException
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }
}
