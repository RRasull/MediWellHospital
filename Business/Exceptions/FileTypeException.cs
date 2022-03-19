using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class FileTypeException : Exception
    {
        public FileTypeException(string message) : base(message)
        {

        }
    }
}
