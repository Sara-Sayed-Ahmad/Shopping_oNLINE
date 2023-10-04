using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public int Id { get; set; }
        public User User { get; set; }

        public bool IsCheck { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<Product> Products { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
