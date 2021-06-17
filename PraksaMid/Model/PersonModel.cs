using System;

namespace PraksaMid.Model
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdRole { get; set; }
        public string RoleName { get; set; }
        public string Address { get; set; }
        public string Oib { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public bool Accepted { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public DateTime Dismissed { get; set; }
    }
}