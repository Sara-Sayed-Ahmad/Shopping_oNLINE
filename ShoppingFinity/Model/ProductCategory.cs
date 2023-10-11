namespace ShoppingFinity.Model
{
    public class ProductCategory
    {
        public int DetailsId { get; set; }
        public DetailsCategory DetailsCategory { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }    
    }
}