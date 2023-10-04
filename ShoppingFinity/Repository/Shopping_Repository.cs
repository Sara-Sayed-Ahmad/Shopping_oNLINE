using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingFinity.Model;
using ShoppingFinity.Model.DTOs;

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

            foreach(var user in users)
            {
                if (user == null)
                {
                    Console.WriteLine($"User Not found: {user}");
                }
            }

            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserById(string userId)
        {
            var user = await _context.User.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user == null)
            {
                Console.WriteLine($"User Not found: {user}");
            }

            return _mapper.Map<UserDTO>(user);
        }
    }
}