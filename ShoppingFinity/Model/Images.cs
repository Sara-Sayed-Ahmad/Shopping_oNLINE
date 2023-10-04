using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model
{
    public class Images
    {
        [Key]
        public int ImageId { get; set; }

        public string ImageName { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string Color { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
