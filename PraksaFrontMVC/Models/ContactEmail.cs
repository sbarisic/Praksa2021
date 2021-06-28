using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Models
{
    public class ContactEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int IdUser { get; set; }
    }
}
