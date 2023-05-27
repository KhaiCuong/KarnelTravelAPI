using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service.ImageService
{
    public class AccommodationImageServiceImp : IAccommodationImageRepository
    {
        private readonly DatabaseContext _dbContext;
        public AccommodationImageServiceImp(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddAccommodationImages([FromForm] List<IFormFile> files, string Accommodation_Id)
        {
            AccommodationModel accommodation = await _dbContext.Accommodations.FindAsync(Accommodation_Id);
            if(accommodation != null)
            {
                if(files.Count > 0 && files != null)
                {
                    foreach (var file in files)
                    {
                        if(file != null && file.Length > 0)
                        {
                            var fileName = Path.GetRandomFileName() + Path.GetFileName(file.FileName);
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads/Accommodations", fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }

                            var image = new AccommodationImageModel
                            {
                                photo_url = "/uploads/Accommodations/" + fileName,
                                Accommodation_id = Accommodation_Id,
                            };


                            await _dbContext.AccommodationImages.AddAsync(image);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteAccommodationImage(string Accommodation_Id)
        {
            AccommodationModel accommodation = await _dbContext.Accommodations.FindAsync(Accommodation_Id);
            if(accommodation != null)
            {
                var oldImg = await _dbContext.AccommodationImages.Where(a => a.Accommodation_id.Equals(Accommodation_Id)).ToListAsync();

                if (oldImg != null)
                {
                    foreach (var image in oldImg)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), image.photo_url.TrimStart('/'));
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            _dbContext.AccommodationImages.Remove(image);
                            await _dbContext.SaveChangesAsync();

                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);

                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<string>> GetAccommodationImage(string Accommodation_Id)
        {
            AccommodationModel accomodation = await _dbContext.Accommodations.FindAsync(Accommodation_Id);
            if (accomodation != null)
            {
                var oldImg = await _dbContext.AccommodationImages.Where(a => a.Accommodation_id.Equals(Accommodation_Id)).ToListAsync();

                if (oldImg != null)
                {
                    List<string> images = new List<string>();
                    string filePath;
                    foreach (var image in oldImg)
                    {
                        filePath = image.photo_url.TrimStart('/');
                        images.Add(filePath);

                    }
                    return images;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<AccommodationImageModel>> GetAllAccommodationImages()
        {
            return await _dbContext.AccommodationImages.ToListAsync();
        }

        public async Task<bool> UpdateAccommodationImage([FromForm] List<IFormFile> files, string Accommodation_Id)
        {
            AccommodationModel accommodation = await _dbContext.Accommodations.FindAsync(Accommodation_Id);
            if (accommodation != null)
            {
                var oldImg = await _dbContext.AccommodationImages.Where(a => a.Accommodation_id.Equals(Accommodation_Id)).ToListAsync();

                if (oldImg != null)
                {
                    foreach (var image in oldImg)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), image.photo_url.TrimStart('/'));
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            _dbContext.AccommodationImages.Remove(image);
                            await _dbContext.SaveChangesAsync();

                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);

                            }
                        }
                    }
                }

                if (files.Count > 0 && files != null)
                {
                    foreach (var file in files)
                    {
                        if (file != null && file.Length > 0)
                        {
                            var fileName = Path.GetRandomFileName() + Path.GetFileName(file.FileName);
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads/Accommodations", fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }

                            var image = new AccommodationImageModel
                            {
                                photo_url = "/uploads/Accommodations/" + fileName,
                                Accommodation_id = Accommodation_Id,
                            };


                            await _dbContext.AccommodationImages.AddAsync(image);
                            await _dbContext.SaveChangesAsync();

                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
