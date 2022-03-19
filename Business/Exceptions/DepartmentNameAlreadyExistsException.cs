using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
   public class DepartmentNameAlreadyExistsException : FileException
    {
        public DepartmentNameAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
