namespace SD_330_F22SD_Labs.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public string PostalCode { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Address() { }
    }
}
