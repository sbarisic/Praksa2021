using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Oib { get; set; }
        public bool Accepted { get; set; }
        public string Password { get; set; }
        public DateTime Dismissed { get; set; }
    }
}
