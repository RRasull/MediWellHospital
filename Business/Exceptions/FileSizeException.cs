using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class FileSizeException : FileException
    {
        public FileSizeException(string message) : base(message)
        {

        }
    }
}
