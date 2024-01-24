using System.ComponentModel.DataAnnotations;

namespace ShoppingFinity.Model.AddDTOs
{
    public class AddFavoriteDTO
    {
        public int ProductId { get; set; }

        public string Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}
