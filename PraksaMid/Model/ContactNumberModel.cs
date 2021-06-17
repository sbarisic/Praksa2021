using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraksaMid.Model
{
    public class ContactNumberModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int IdUser { get; set; }
    }
}