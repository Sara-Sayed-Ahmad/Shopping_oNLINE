namespace ShoppingFinity.Model.GetDTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public string Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int PaymentId { get; set; }

        public string PaymentStatus { get; set; }

        public string OrderStatus { get; set; }

        public string ShippingType { get; set; }

        public float ShippingFee { get; set; }

        public bool ShippingFree { get; set; }

        public float TotalAmount { get; set; }

        public int TrackingNum { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
