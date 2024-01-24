namespace ShoppingFinity.Model.AddDTOs
{
    public class AddOrder
    {
        public string UserId { get; set; }

        public int PaymentTypeId { get; set; }

        public int DiscountId { get; set; }

        public string PaymentStatus { get; set; }

        public float TotalAmount { get; set; }

        public string OrderStatus { get; set; }

        public string ShippingType { get; set; }

        public float ShippingFee { get; set; }

        public bool ShippingFree {  get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime OrderDate { get; set; }

        public List<ProductList> products { get; set; }
    }
}
