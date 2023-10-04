using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model
{
    public class DetailsCategory
    {
        [Key]
        public int DetailsId { get; set; }

        public string DetailName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}