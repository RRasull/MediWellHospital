using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class SetPasswordException : UserException
    {
        public SetPasswordException(string message) : base(message)
        {
        }
    }
}
