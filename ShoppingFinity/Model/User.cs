using Microsoft.AspNetCore.Identity;

namespace ShoppingFinity.Model
{
    public class User : IdentityUser 
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Address { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Governorate { get; set; }

        public string? ZipCode { get; set; }

        public int StreetNum { get; set; }

        public int ApartmentNum { get; set; }

        public string AuthenticationToken { get; set; }

        public DateTime LastLoginDate { get; set; }

        public bool IsAdmin { get; set; }

        //Navegation Properites 
        public ICollection<Product> Products { get; set; }

        public ICollection<PaymentType> PaymentType { get; set; }

        public List<Favorite> Favorites { get; set; }

        public List<PaymentTypeUser> PaymentTypeUsers { get; set; }

        public List<ProductReview> ProductReviews { get; set; }

        public List<Order> Orders { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}