using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace KarnelTravelAPI.Service.ImageService
{
    public class LocationImageServiceImp:ILocationImageRepository
    {
        private readonly DatabaseContext _databaseContext;
        public LocationImageServiceImp(DatabaseContext databaseContext, IWebHostEnvironment webHostEnvironment)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> AddLocationImageAsync(List<IFormFile>? files, string Location_id)
        {
            LocationModel loca = await _databaseContext.Locations.FindAsync(Location_id);
            if (loca != null)
            {
                if (files.Count > 0 && files != null)
                {
                    foreach (var file in files)
                    {
                        if (file != null && file.Length > 0)
                        {
                            var fileName = Path.GetRandomFileName() + Path.GetFileName(file.FileName);
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads/Locations", fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }

                            var image = new LocationImageModel
                            {
                                photo_url = "/uploads/Locations/" + fileName,
                                Location_id = Location_id,
                            };


                            await _databaseContext.LocationImages.AddAsync(image);
                            await _databaseContext.SaveChangesAsync();

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

        public async Task<bool> DeleteLocationImageAsync(string Location_id)
        {
            LocationModel loca = await _databaseContext.Locations.FindAsync(Location_id);
            if (loca != null)
            {
                var oldImg = await _databaseContext.LocationImages.Where(g => g.Location_id.Equals(Location_id)).ToListAsync();

                if (oldImg != null)
                {
                    foreach (var img in oldImg)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), img.photo_url.TrimStart('/'));
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            _databaseContext.LocationImages.Remove(img);
                            await _databaseContext.SaveChangesAsync();

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

        public async Task<IEnumerable<string>> GetLocationImageByIdAsync(string Location_id)
        {
            LocationModel loca = await _databaseContext.Locations.FindAsync(Location_id);
            if (loca != null)
            {
                var oldImg = await _databaseContext.LocationImages.Where(g => g.Location_id.Equals(Location_id)).ToListAsync();

                if (oldImg != null)
                {
                    List<string> images = new List<string>();
                    string filePath;
                    foreach (var img in oldImg)
                    {
                        filePath = img.photo_url.TrimStart('/');
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

        public Task<IEnumerable<TouristSpotImageModel>> GetLocationImagesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateLocationImgAsync(List<IFormFile> files, string Location_id)
        {
            LocationModel loca = await _databaseContext.Locations.FindAsync(Location_id);
            if (loca != null)
            {
                var oldImg = await _databaseContext.LocationImages.Where(g => g.Location_id.Equals(Location_id)).ToListAsync();

                if (oldImg != null)
                {
                    foreach (var img in oldImg)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), img.photo_url.TrimStart('/'));
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            _databaseContext.LocationImages.Remove(img);
                            await _databaseContext.SaveChangesAsync();

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
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads/Locations", fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }

                            var image = new LocationImageModel
                            {
                                photo_url = "/uploads/Locations/" + fileName,
                                Location_id = Location_id,
                            };


                            await _databaseContext.LocationImages.AddAsync(image);
                            await _databaseContext.SaveChangesAsync();

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
