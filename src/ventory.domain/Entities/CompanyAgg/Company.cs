using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventory.domain.Entities.UserAgg;

namespace ventory.domain.Entities.CompanyAgg
{
    public class Company
    {
        //Supply properties inline with user of the inventory system with POS
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public List<User> Users { get; set; }
        
    }
}