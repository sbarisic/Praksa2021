using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraksaMid.Users
{
    public class User
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Oib { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
    }
}