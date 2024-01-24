namespace ShoppingFinity.Model.GetDTOs
{
    public class DiscountDTO
    {
        public int DiscountId { get; set; }

        public string DiscontType { get; set; }

        public float Percentage { get; set; }

        public DateTime EndDate { get; set; }

        public List<OrderDTO> Orders { get; set; }
    }
}
