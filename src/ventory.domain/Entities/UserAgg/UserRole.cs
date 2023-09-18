using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ventory.domain.Entities.UserAgg
{
    public class UserRole
    {
        public Guid Id { get; set; }
        public RoleType Role { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}