using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model.AddDTOs
{
    public class AddProductDTO
    {
        [Required(ErrorMessage ="Product Name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Category is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Price of product is required")]
        public float Price { get; set; }

        public float DiscountPercentage { get; set; }

        [Required(ErrorMessage ="Quantity of product is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage ="Please enter, if product is avaliable or not")]
        public bool IsAvaliable { get; set; }

        public int CountOrder { get; set; }

        [Required(ErrorMessage ="Season is required")]
        public string Season { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        public List<int> DetailsId { get; set; }
    }
}