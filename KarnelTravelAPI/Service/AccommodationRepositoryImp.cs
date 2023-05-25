using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Repository;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service
{
    public class AccommodationRepositoryImp : IAccommodationRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly string _uploadFolder;

        public AccommodationRepositoryImp(DatabaseContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _uploadFolder = Path.Combine(webHostEnvironment.ContentRootPath, "uploads");
        }

        public async Task<AccommodationModel> AddAccommodation(AccommodationModel Accommodation, ICollection<IFormFile>? files)
        {
            if(Accommodation != null)
            {
                await _dbContext.Accommodations.AddAsync(Accommodation);
                await _dbContext.SaveChangesAsync();
                // save uploaded images to server
                if(files.Count > 0)
                {
                    foreach(var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = Path.GetRandomFileName() + Path.GetFileName(file.FileName);
                            var filePath = Path.Combine(_uploadFolder, fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                            var image = new AccommodationImageModel
                            {
                                photo_url = "/uploads" + fileName,
                                Accommodation_id = Accommodation.Accommodation_id,
                            };
                            await _dbContext.AccommodationImages.AddAsync(image);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                }
            }
            return Accommodation;
        }

        public async Task<bool> DeleteAccommodation(string Accommodation_id)
        {
            var existingAccomodation = await _dbContext.Accommodations.Include(a => a.AccommodationImages).FirstOrDefaultAsync(a => a.Accommodation_id.Equals(Accommodation_id));
            foreach (var image in existingAccomodation.AccommodationImages)
            {
                var imagePath = Path.Combine(_uploadFolder, image.photo_url.TrimStart('/'));
                if(System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            // remove accommodation and its images from database
            _dbContext.Accommodations.Remove(existingAccomodation);
            await _dbContext.SaveChangesAsync();
            return true;
            /*throw new NotImplementedException();*/

        }

        public async Task<AccommodationModel> GetAccommodationById(string Accommodation_id)
        {
            AccommodationModel accommodation = await _dbContext.Accommodations.Include(a => a.AccommodationImages).FirstOrDefaultAsync(a => a.Accommodation_id.Equals(Accommodation_id));
            if(accommodation != null)
            {
                return accommodation;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<AccommodationModel>> GetAccommodations()
        {
            return await _dbContext.Accommodations.ToListAsync();
        }

        public async Task<AccommodationModel> UpdateAccommodation(AccommodationModel Accommodation, ICollection<IFormFile>? files)
        {
            var existingAccommodation = await _dbContext.Accommodations.Include(a => a.AccommodationImages).FirstOrDefaultAsync(a => a.Accommodation_id.Equals(Accommodation.Accommodation_id));
            if(existingAccommodation != null)
            {
                //update product properties
                existingAccommodation.Accommodation_name = Accommodation.Accommodation_name;
                existingAccommodation.Type = Accommodation.Type;
                existingAccommodation.Description = Accommodation.Description;
                existingAccommodation.Price = Accommodation.Price;
                // update associated file
                if(files != null && files.Count > 0)
                {
                    // xoa file
                    foreach(var image in existingAccommodation.AccommodationImages)
                    {
                        var imagePath = Path.Combine(_uploadFolder, image.photo_url.TrimStart('/'));
                        if(System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    // Delete existing image
                    _dbContext.RemoveRange(existingAccommodation.AccommodationImages);
                    foreach (var file in files)
                    {
                        var fileaName = Path.GetRandomFileName() + Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(_uploadFolder, fileaName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        var image = new AccommodationImageModel
                        {
                            photo_url = "/uploads" + fileaName,
                            Accommodation_id = Accommodation.Accommodation_id,
                        };
                        _dbContext.AccommodationImages.Add(image);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                return Accommodation;
            }
            return Accommodation;
        }
    }
}
