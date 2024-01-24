using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model
{
    public class ProductReview
    {
        [Key]
        public int ReviewId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public string Title { get; set; }

        public int Rating { get; set; }

        public string Description { get; set; }

        public DateTime DateReview { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}