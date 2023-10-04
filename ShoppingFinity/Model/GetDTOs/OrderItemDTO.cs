namespace ShoppingFinity.Model.GetDTOs
{
    public class OrderItemDTO
    {
        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public float ItemPrice { get; set; }

        public float SubTotal { get; set; }

        public string? DiscountType { get; set; }
    }
}
