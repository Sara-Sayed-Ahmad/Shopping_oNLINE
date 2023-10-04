namespace ShoppingFinity.Model.GetDTOs
{
    public class FavoriteDTO
    {
        public int ProductId { get; set; }

        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
