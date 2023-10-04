namespace ShoppingFinity.Model.GetDTOs
{
    public class ProductReviewDTO
    {
        public int ReviewId { get; set; }

        public int ProductId { get; set; }

        public string Id { get; set; }

        public string Title { get; set; }

        public int Rating { get; set; }

        public string Description { get; set; }

        public DateTime DateReview { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
