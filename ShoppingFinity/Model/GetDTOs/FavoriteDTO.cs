namespace ShoppingFinity.Model.GetDTOs
{
    public class FavoriteDTO
    {
        public int ProductId { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
