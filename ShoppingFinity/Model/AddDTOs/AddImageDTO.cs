using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model.AddDTOs
{
    public class AddImageDTO
    {
        public List<IFormFile> Image { get; set; }

        [Required(ErrorMessage ="Product Name is required")]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Color of product is required")]
        public string Color { get; set; }

        [Required(ErrorMessage ="Date of added is required")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}
