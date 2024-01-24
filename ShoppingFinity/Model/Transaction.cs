using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}