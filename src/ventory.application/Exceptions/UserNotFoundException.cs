using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ventory.application.Exceptions
{
    public class UserNotFoundException: Exception
    {
        public UserNotFoundException(Guid userId): base($"User with id {userId} was not found")
        {
            
        }

        public UserNotFoundException(string email) : base($"User with email {email} was not found")
        {

        }

    }
}