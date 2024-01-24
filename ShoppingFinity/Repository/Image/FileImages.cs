using AutoMapper;
using ShoppingFinity.Model.AddDTOs;
using ShoppingFinity.Model;
using System.Collections.Generic;
using ShoppingFinity.Model.GetDTOs;
using Microsoft.EntityFrameworkCore;

namespace ShoppingFinity.Repository.Image
{
    public class FileImages : IFileImages
    {
        private SystemDbContext _context;
        private IMapper _mapper;

        public FileImages(SystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        //Upload Images for product by admin
        public async Task<List<string>> UploadImage(AddImageDTO image)
        {
            List<string> ImageName = new List<string>(); 
            
            try 
            {
                foreach (var file in image.Image)
                {
                    var extension = file.FileName;
                    ImageName.Add(extension);

                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload");

                    if (!Directory.Exists(imagePath))
                    {
                        Directory.CreateDirectory(imagePath);
                    }

                    var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload", extension);

                    using (var stream = new FileStream(exactpath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var product = await _context.Products.Where(x => x.ProductId == image.ProductId).FirstOrDefaultAsync();

                    if (product != null)
                    {
                        var newImage = new Images
                        {
                            ImageName = extension,
                            ProductId = image.ProductId,
                            Color = image.Color,
                            CreatedAt = image.CreatedAt
                        };
                        _context.Images.Add(newImage);
                    }

                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return ImageName;
        }

        public async Task<List<ImagesDTO>> GetImageById(int idProduct)
        {
            var image = await _context.Images.Where(x => x.ProductId == idProduct).ToListAsync();
            
            return _mapper.Map<List<ImagesDTO>>(image);
        }
    }
}