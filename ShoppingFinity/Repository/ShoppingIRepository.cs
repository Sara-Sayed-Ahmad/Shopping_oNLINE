using ShoppingFinity.Model.AddDTOs;
using ShoppingFinity.Model.DTOs;

namespace ShoppingFinity.Repository
{
    public interface ShoppingIRepository
    {
        Task<List<UserDTO>> GetAllUsers();

        Task<UserDTO> GetUserById(string userId);

        Task AddCategories(AddCategoryDTO dataCategory);

        Task AddDetailsCategory(AddDetailsDTO detailsCategory);
    }
}
