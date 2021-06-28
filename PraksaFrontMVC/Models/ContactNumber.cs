using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Models
{
    public class ContactNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int IdUser { get; set; }
    }
}
