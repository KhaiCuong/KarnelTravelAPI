using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace KarnelTravelAPI.Service.ImageService
{
    public class TouristSpotImageServiceImp : ITouristSpotImageRepository
    {
        private readonly DatabaseContext _databaseContext;
        public TouristSpotImageServiceImp(DatabaseContext databaseContext, IWebHostEnvironment webHostEnvironment)
        {
            _databaseContext = databaseContext;
        }
        public async Task<bool> DeleteImage(string TouristSpot_Id)
        {
            TouristSpotModel spot = await _databaseContext.TouristSpots.FindAsync(TouristSpot_Id);
            if (spot != null)
            {
                var oldImg = await _databaseContext.TouristSpotImages.Where(g => g.TouristSpot_id.Equals(TouristSpot_Id)).ToListAsync();

                if (oldImg != null)
                {
                    foreach (var img in oldImg)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), img.photo_url.TrimStart('/'));
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            _databaseContext.TouristSpotImages.Remove(img);
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
            } else
            {
                return false;
            }
        }

        public async Task<bool> AddImage(List<IFormFile>? files, string TouristSpot_Id)
        {
            TouristSpotModel spot = await _databaseContext.TouristSpots.FindAsync(TouristSpot_Id);
                
            if(spot != null)
            {
                if (files.Count > 0 && files != null)
                {
                    foreach (var file in files)
                    {
                        if (file != null && file.Length > 0)
                        {
                            var fileName = Path.GetRandomFileName() + Path.GetFileName(file.FileName);
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads/TouristSpots", fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }

                            var image = new TouristSpotImageModel
                            {
                                photo_url = "http://localhost:5158/uploads/TouristSpots/" + fileName,
                                TouristSpot_id = TouristSpot_Id,
                            };


                            await _databaseContext.TouristSpotImages.AddAsync(image);
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

        public Task<IEnumerable<TouristSpotImageModel>> AllImgs()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string>> GetListImgById(string TouristSpot_Id)
        {
            TouristSpotModel spot = await _databaseContext.TouristSpots.FindAsync(TouristSpot_Id);
            if (spot != null)
            {
                var oldImg = await _databaseContext.TouristSpotImages.Where(g => g.TouristSpot_id.Equals(TouristSpot_Id)).ToListAsync();

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

                }else
                {
                    return null;

                }

            }
            else
            {
                return null;
            }

        }

        public async Task<bool> UpdateImg(List<IFormFile> files, string TouristSpot_Id)
        {
            TouristSpotModel spot = await _databaseContext.TouristSpots.FindAsync(TouristSpot_Id);
            if (spot != null)
            {
                var oldImg = await _databaseContext.TouristSpotImages.Where(g => g.TouristSpot_id.Equals(TouristSpot_Id)).ToListAsync();

                if (oldImg != null)
                {
                    foreach (var img in oldImg)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), img.photo_url.TrimStart('/'));
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            _databaseContext.TouristSpotImages.Remove(img);
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
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads/TouristSpots", fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }

                            var image = new TouristSpotImageModel
                            {
                                photo_url = "http://localhost:5158/uploads/TouristSpots/" + fileName,
                                TouristSpot_id = TouristSpot_Id,
                            };


                            await _databaseContext.TouristSpotImages.AddAsync(image);
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
