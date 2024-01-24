namespace ShoppingFinity.Model.GetDTOs
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }

        public string UserId { get; set; }

        public int OrderId { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}