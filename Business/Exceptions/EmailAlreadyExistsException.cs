using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
