using ShoppingFinity.Model.GetDTOs;

namespace ShoppingFinity.Model.DTOs
{
    public class UserDTO
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

        public List<FavoriteDTO> Favorites { get; set; }

        public List<PaymentTypeUserDTO> PaymentTypeUsers { get; set; }

        public List<ProductReviewDTO> ProductReviews { get; set; }

        public List<CartDTO> Carts { get; set; }

        public List<OrderDTO> Orders { get; set; }

        public List<TransactionDTO> Transactions { get; set; }
    }
}
