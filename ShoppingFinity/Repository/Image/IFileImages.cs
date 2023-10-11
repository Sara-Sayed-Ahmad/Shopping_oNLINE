using ShoppingFinity.Model.AddDTOs;

namespace ShoppingFinity.Repository.Image
{
    public interface IFileImages
    {
        //Upload image for each product by admin
        Task<List<string>> UploadImage(AddImageDTO image);
    }
}
