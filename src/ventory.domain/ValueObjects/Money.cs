using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ventory.domain.ValueObjects
{
    public class Money
    {
        //Supply properties
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        
    }
}