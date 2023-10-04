namespace ShoppingFinity.Model.GetDTOs
{
    public class ImagesDTO
    {
        public int ImageId { get; set; }

        public string ImageName { get; set; }

        public int ProductId { get; set; }

        public string Color { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
