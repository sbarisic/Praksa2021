using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Obligation { get; set; }
        public Attendant Attendant { get; set; }
    }
}
