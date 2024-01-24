namespace ShoppingFinity.Model
{
    public class Discount
    {
        public int DiscountId { get; set; }

        public string DiscontType { get; set; }

        public float Percentage { get; set; }

        public DateTime EndDate { get; set; }

        public List<Order> Orders { get; set; }
    }
}