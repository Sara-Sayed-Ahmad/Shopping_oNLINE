using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingFinity.Model;
using ShoppingFinity.Model.AddDTOs;
using ShoppingFinity.Model.DTOs;
using ShoppingFinity.Model.GetDTOs;

namespace ShoppingFinity.Repository
{
    public class Shopping_Repository: ShoppingIRepository
    {
        private readonly SystemDbContext _context;
        private readonly IMapper _mapper;

        public Shopping_Repository(SystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get All Users
        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _context.User.Include(c => c.Carts).ToListAsync();

            return _mapper.Map<List<UserDTO>>(users);
        }

        //Get User by Id
        public async Task<UserDTO> GetUserById(string userId)
        {
            var user = await _context.User.Where(u => u.Id == userId).FirstOrDefaultAsync();

            return _mapper.Map<UserDTO>(user);
        }

        //Get all categories
        public async Task<List<CategoryDTO>> GetCategories()
        {
            var category = await _context.Categories
                .Include(p => p.Products).ToListAsync();

            return _mapper.Map<List<CategoryDTO>>(category);
        }

        //Get category by Id
        public async Task<CategoryDTO> GetCategory(int categoryId)
        {
            var category = await _context.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefaultAsync();   

            return _mapper.Map<CategoryDTO>(category);
        }

        //Get all detials of category
        public async Task<List<DetailsCategoryDTO>> GetDetails()
        {
            var Detcategory = await _context.DetailsCategories
                .Include(c => c.Category).ToListAsync();

            return _mapper.Map<List<DetailsCategoryDTO>>(Detcategory);
        }

        //Get category by Id
        public async Task<DetailsCategoryDTO> GetDetailsById(int detailsId)
        {
            var DetailCate = await _context.DetailsCategories.Where(c => c.DetailsId == detailsId).FirstOrDefaultAsync();

            return _mapper.Map<DetailsCategoryDTO>(DetailCate);
        }

        //Get Products
        public async Task<List<ProductDTo>> GetProducts()
        {
            var product = await _context.Products
                .Include(img => img.Images)
                .Include(s => s.SizeProducts)
                .Include(c => c.Category)
                .Include(dc => dc.ProductCategories).ToListAsync();

            return _mapper.Map<List<ProductDTo>>(product);
        }

        //Get Product by id
        public async Task<ProductDTo> GetProductById(int id)
        {
            var product = await _context.Products.Include(img => img.Images)
                .Include(s => s.SizeProducts).Include(c => c.Category)
                .Include(dc => dc.ProductCategories)
                .Where(p => p.ProductId == id).FirstOrDefaultAsync();

            return _mapper.Map<ProductDTo>(product);
        }

        //Add Category by admin
        public async Task AddCategories(AddCategoryDTO dataCategory)
        {
            var category = new Category()
            {
                CategoryName = dataCategory.CategoryName,
                Description = dataCategory.Description,
                CreatedAt = dataCategory.CreatedAt
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        //Add details for each category added by admin
        public async Task AddDetailsCategory(AddDetailsDTO detailsCategory)
        {
            var details = new DetailsCategory()
            {
                DetailName = detailsCategory.DetailName,
                CreatedAt = detailsCategory.CreatedAt,
                CategoryId = detailsCategory.CategoryId
            };

            _context.DetailsCategories.Add(details);
            await _context.SaveChangesAsync();
        }

        //Add product by Id
        public async Task AddProduct(AddProductDTO product)
        {
            //var newProduct = new Product()
            //{
            //    ProductName = product.ProductName,
            //    Description = product.Description,
            //    CategoryId = product.CategoryId,
            //    Price = product.Price,
            //    DiscountPercentage = product.DiscountPercentage,
            //    Quantity = product.Quantity,
            //    IsAvaliable = product.IsAvaliable,
            //    Season = product.Season,
            //    CreatedAt = product.CreatedAt,
            //};
            var newProduct = _mapper.Map<Product>(product);

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
        }

        //Add Size for product by admin
        public async Task AddSizeProduct(AddSizeDTO size)
        {
            var sizeProd = new SizeProduct()
            {
                SizeName = size.SizeName,
                ProductId = size.ProductId
            };

            _context.SizeProducts.Add(sizeProd);
            await _context.SaveChangesAsync();
        }
    }
}