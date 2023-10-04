using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model
{
    public class PaymentType
    {
        [Key]
        public int PaymentId { get; set; }
        public string PaymentName { get; set; }

        public int CountNumberOrder { get; set; }

        public List<Order> Orders { get; set; }

        public ICollection<User> Users { get; set; }

        public List<PaymentTypeUser> PaymentTypeUsers { get; set; }
    }
}