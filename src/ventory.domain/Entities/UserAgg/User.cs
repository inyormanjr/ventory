using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventory.domain.Entities.CompanyAgg;

namespace ventory.domain.Entities.UserAgg
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<UserRole> UserRole { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}