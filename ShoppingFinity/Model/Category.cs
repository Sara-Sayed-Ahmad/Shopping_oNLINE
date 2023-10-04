using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public List<Product> Products { get; set; }

        public List<DetailsCategory> DetailsCategories { get; set; }
    }
}
