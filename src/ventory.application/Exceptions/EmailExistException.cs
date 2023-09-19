using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ventory.application.Exceptions
{
    public class EmailExistException: Exception
    {
        public EmailExistException(string email): base($"Email {email} already exist")
        {
            
        }   
    }
}