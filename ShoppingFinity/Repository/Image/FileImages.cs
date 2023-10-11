using AutoMapper;
using ShoppingFinity.Model.AddDTOs;
using ShoppingFinity.Model;
using System.Collections.Generic;

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
        
        public async Task<List<string>> UploadImage(AddImageDTO image)
        {
            List<string> ImageName = new List<string>(); 
            
            try 
            {
                foreach (var file in image.Image)
                {
                    var extension = file.FileName;
                    ImageName.Add(extension);

                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload");

                    if (!Directory.Exists(imagePath))
                    {
                        Directory.CreateDirectory(imagePath);
                    }

                    var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "upload", extension);

                    using (var stream = new FileStream(exactpath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var newImage = new Images
                    {
                        ImageName = extension,
                        ProductId = image.ProductId,
                        Color = image.Color,
                        CreatedAt = image.CreatedAt
                    };

                    _context.Images.Add(newImage);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
            //string ImageName = "";

            //try
            //{
            //    var extension = image.Image.FileName;
            //    ImageName = extension;

            //    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload");
                
            //    if (!Directory.Exists(imagePath))
            //    {
            //        Directory.CreateDirectory(imagePath);
            //    }

            //    var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "upload", ImageName);

            //    using (var stream = new FileStream(exactpath, FileMode.Create))
            //    {
            //        await image.Image.CopyToAsync(stream);
            //    }

            //    var newImage = new List<Images>
            //    {
            //        new Images
            //        {
            //            ImageName = ImageName,
            //            ProductId = image.ProductId,
            //            Color = image.Color,
            //            CreatedAt = image.CreatedAt
            //        }
            //    };

            //    _context.Images.AddRange(newImage);
            //    await _context.SaveChangesAsync();
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine("Error: " + ex.Message);
            //}

            return ImageName;
        }
    }
}