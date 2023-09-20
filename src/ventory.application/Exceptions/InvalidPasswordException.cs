using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ventory.application.Exceptions
{
    public class InvalidPasswordException: Exception
    {
        //implement
        public InvalidPasswordException(): base($"Password is invalid")
        {
            
        }
    }
}