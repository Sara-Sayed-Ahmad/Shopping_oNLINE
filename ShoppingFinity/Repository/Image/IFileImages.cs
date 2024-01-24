using ShoppingFinity.Model.AddDTOs;
using ShoppingFinity.Model.GetDTOs;

namespace ShoppingFinity.Repository.Image
{
    public interface IFileImages
    {
        //Upload image for each product by admin
        Task<List<string>> UploadImage(AddImageDTO image);

        Task<List<ImagesDTO>> GetImageById(int idProduct);
    }
}
