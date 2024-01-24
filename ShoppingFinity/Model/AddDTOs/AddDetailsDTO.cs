using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model.AddDTOs
{
    public class AddDetailsDTO
    {
        [Required(ErrorMessage = "Details Name is required")]
        public string DetailName { get; set; }

        [Required(ErrorMessage = "Date for added is required")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        public int CategoryId { get; set; }
    }
}