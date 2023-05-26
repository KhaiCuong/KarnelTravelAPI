using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service
{
    public class ResImgServiceImp:IRestaurantImageRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ResImgServiceImp(DatabaseContext databaseContext, IWebHostEnvironment webHostEnvironment)
        {
            _databaseContext = databaseContext;
        }
        public async Task<bool> DeleteImage(string Restaurant_id)
        {
            RestaurantModel res = await _databaseContext.Restaurants.FindAsync(Restaurant_id);
            if (res != null)
            {
                var oldImg = await _databaseContext.RestaurantImages.Where(g => g.Restaurant_id.Equals(Restaurant_id)).ToListAsync();

                if (oldImg != null)
                {
                    foreach (var img in oldImg)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), img.photo_url.TrimStart('/'));
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            _databaseContext.RestaurantImages.Remove(img);
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

        public async Task<bool> AddImage(List<IFormFile>? files, string Restaurant_id)
        {
            RestaurantModel res = await _databaseContext.Restaurants.FindAsync(Restaurant_id);

            if (res != null)
            {
                if (files.Count > 0 && files != null)
                {
                    foreach (var file in files)
                    {
                        if (file != null && file.Length > 0)
                        {
                            var fileName = Path.GetRandomFileName() + Path.GetFileName(file.FileName);
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads/Restaurant", fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }

                            var image = new RestaurantImageModel
                            {
                                photo_url = "/uploads/Restaurant/" + fileName,
                                Restaurant_id = Restaurant_id,
                            };


                            await _databaseContext.RestaurantImages.AddAsync(image);
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

        public Task<IEnumerable<RestaurantImageModel>> AllImgs()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string>> GetListImgById(string Restaurant_id)
        {
            RestaurantModel spot = await _databaseContext.Restaurants.FindAsync(Restaurant_id);
            if (spot != null)
            {
                var oldImg = await _databaseContext.RestaurantImages.Where(g => g.Restaurant_id.Equals(Restaurant_id)).ToListAsync();

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

        public async Task<bool> UpdateImg(List<IFormFile> files, string Restaurant_id)
        {
            RestaurantModel spot = await _databaseContext.Restaurants.FindAsync(Restaurant_id);
            if (spot != null)
            {
                var oldImg = await _databaseContext.RestaurantImages.Where(g => g.Restaurant_id.Equals(Restaurant_id)).ToListAsync();

                if (oldImg != null)
                {
                    foreach (var img in oldImg)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), img.photo_url.TrimStart('/'));
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            _databaseContext.RestaurantImages.Remove(img);
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
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads/Restaurant", fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }

                            var image = new RestaurantImageModel
                            {
                                photo_url = "/uploads/Restaurant/" + fileName,
                                Restaurant_id = Restaurant_id,
                            };


                            await _databaseContext.RestaurantImages.AddAsync(image);
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
