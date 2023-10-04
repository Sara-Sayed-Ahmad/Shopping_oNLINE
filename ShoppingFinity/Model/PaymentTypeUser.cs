namespace ShoppingFinity.Model
{
    public class PaymentTypeUser
    {
        public int PaymentId { get; set; }
        public PaymentType PaymentType { get; set; }

        public string Id { get; set; }
        public User User { get; set; }
    }
}
