using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model.AddDTOs
{
    public class AddCategoryDTO
    {
        [Required(ErrorMessage ="Category Name is required")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Description for category is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}
