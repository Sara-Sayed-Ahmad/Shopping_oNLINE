using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model.AddDTOs
{
    public class AddSizeDTO
    {
        [Required(ErrorMessage ="Size Name is required")]
        public string SizeName { get; set; }

        [Required(ErrorMessage ="Product Name is required")]
        public int ProductId { get; set; }
    }
}