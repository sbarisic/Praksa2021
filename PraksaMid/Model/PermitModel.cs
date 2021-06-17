namespace PraksaMid.Model
{
    public class PermitModel
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