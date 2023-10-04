using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model
{
    public class SizeProduct
    {
        [Key]
        public int SizeId { get; set; }

        public string SizeName { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}