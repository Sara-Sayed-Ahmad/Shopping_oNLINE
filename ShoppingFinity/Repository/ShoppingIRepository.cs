using ShoppingFinity.Model.AddDTOs;
using ShoppingFinity.Model.DTOs;
using ShoppingFinity.Model.GetDTOs;

namespace ShoppingFinity.Repository
{
    public interface ShoppingIRepository
    {
        //Get Data:

        //Get all users in database
        Task<List<UserDTO>> GetAllUsers();

        //Get user by Id
        Task<UserDTO> GetUserById(string userId);

        //Get categoryies
        Task<List<CategoryDTO>> GetCategories();

        //Get category by Id
        Task<CategoryDTO> GetCategory(int categoryId);

        //Get details category
        Task<List<DetailsCategoryDTO>> GetDetails();

        //Get details category by id
        Task<DetailsCategoryDTO> GetDetailsById(int detailsId);

        //Get all Products
        Task<List<ProductDTo>> GetProducts();

        //Get product by id
        Task<ProductDTo> GetProductById(int id);

        //Add Data:

        //- Added by admin:

        //1. Add Category
        Task AddCategories(AddCategoryDTO dataCategory);

        //2. Add details for each category added
        Task AddDetailsCategory(AddDetailsDTO detailsCategory);

        //3. Add product
        Task AddProduct(AddProductDTO product);

        //4. Add Size for product
        Task AddSizeProduct(AddSizeDTO size);
    }
}