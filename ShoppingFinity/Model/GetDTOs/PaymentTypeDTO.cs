namespace ShoppingFinity.Model.GetDTOs
{
    public class PaymentTypeDTO
    {
        public int PaymentId { get; set; }
        public string PaymentName { get; set; }

        public int CountNumberOrder { get; set; }

        public List<OrderDTO> Orders { get; set; }

        public List<PaymentTypeUserDTO> PaymentTypeUsers { get; set; }
    }
}
