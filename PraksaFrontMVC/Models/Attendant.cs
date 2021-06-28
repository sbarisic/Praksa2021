using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Models
{
    public class Attendant
    {
        public int Id { get; set; }
        public int IdJob { get; set; }
        public int IdUser { get; set; }
        public int IdInteres { get; set; }
        public int IdAttendance { get; set; }
        public string SelectionTime { get; set; }

    }
}
