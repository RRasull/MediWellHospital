using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class SetUserNameException : UserException
    {
        public SetUserNameException(string message) : base(message)
        {

        }
    }
}
