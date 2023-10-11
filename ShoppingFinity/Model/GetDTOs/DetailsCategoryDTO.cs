namespace ShoppingFinity.Model.GetDTOs
{
    public class DetailsCategoryDTO
    {
        public int DetailsId { get; set; }

        public string DetailName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int CategoryId { get; set; }

        public List<ProductCategoryDTO> ProductCategories { get; set; }
    }
}