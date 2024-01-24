using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model.AddDTOs
{
    public class AddImageDTO
    {
        [JsonProperty("image")]
        public List<IFormFile> Image { get; set; }

        [JsonProperty("productId")]
        [Required(ErrorMessage ="Product Name is required")]
        public int ProductId { get; set; }

        [JsonProperty("color")]
        [Required(ErrorMessage ="Color of product is required")]
        public string Color { get; set; }

        [JsonProperty("createdAt")]
        [Required(ErrorMessage ="Date of added is required")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
    }
}
