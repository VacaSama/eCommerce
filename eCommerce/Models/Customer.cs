namespace eCommerce.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }
        public string? Phone { get; set; }

        public required string StreetAddress { get; set; } 

        public required string City { get; set; }

        public required string State { get; set; }
    }
}
