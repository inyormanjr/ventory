using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ventory.application.models
{
    public class UserResponseModel
    {
        //populate 
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName {get; set;}
        public string Email { get; set; }

    }
}