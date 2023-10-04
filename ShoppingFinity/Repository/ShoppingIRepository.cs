using ShoppingFinity.Model.DTOs;

namespace ShoppingFinity.Repository
{
    public interface ShoppingIRepository
    {
        Task<List<UserDTO>> GetAllUsers();

        Task<UserDTO> GetUserById(string userId);
    }
}
