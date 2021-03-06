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
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Job { get; set; }
        public string Interes { get; set; }
        public string Attendance { get; set; }
    }
}
