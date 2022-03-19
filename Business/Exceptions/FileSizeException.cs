using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class FileSizeException : Exception
    {
        public FileSizeException(string message) : base(message)
        {

        }
    }
}
