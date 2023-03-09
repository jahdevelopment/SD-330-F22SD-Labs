namespace SD_330_F22SD_Labs.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string? CompanyName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual HashSet<CustomerAddress> CustomerAddresses { get; set; } = new HashSet<CustomerAddress?>();
        public Customer() { }
    }
}
