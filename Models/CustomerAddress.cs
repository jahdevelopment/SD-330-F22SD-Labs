namespace SD_330_F22SD_Labs.Models
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
        public bool IsOwner { get; set; }


        public CustomerAddress()
        {

        }

        public CustomerAddress(Customer customer, Address address, bool isOwner)
        {
            Customer = customer;
            CustomerId = customer.CustomerId;

            Address = address;
            AddressId = address.AddressId;

            IsOwner = isOwner;
        }

    }
}
