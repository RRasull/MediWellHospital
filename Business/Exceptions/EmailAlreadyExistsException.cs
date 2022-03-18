using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class EmailAlreadyExistsException : FileException
    {
        public EmailAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
