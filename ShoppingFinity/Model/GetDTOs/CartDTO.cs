namespace ShoppingFinity.Model.GetDTOs
{
    public class CartDTO
    {
        public int CartId { get; set; }

        public int Id { get; set; }

        public bool IsCheck { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}