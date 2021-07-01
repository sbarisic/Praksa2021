using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Models
{
    public class Permit
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdPermit { get; set; }
        public string ExpiryDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PermitName { get; set; }
        public string PermitNumber { get; set; }
    }
}
