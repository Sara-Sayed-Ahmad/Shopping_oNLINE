namespace ShoppingFinity.Model.GetDTOs
{
    public class CartItemDTO
    {
        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public float ItemPrice { get; set; }

        public float SubTotal { get; set; }
    }
}
