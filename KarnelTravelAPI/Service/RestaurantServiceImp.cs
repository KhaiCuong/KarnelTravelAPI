using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Repository;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service
{
    public class RestaurantServiceImp : IRestaurantRepository
    {
        /*private  string _uploadFolder;*/
        private readonly DatabaseContext context;
        public RestaurantServiceImp(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<RestaurantModel> AddRestaurant(RestaurantModel Restaurant, ICollection<IFormFile> files)
        {
            if (Restaurant != null)
            {
                await context.Restaurants.AddAsync(Restaurant);
                await context.SaveChangesAsync();
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = Path.GetRandomFileName() + Path.GetFileName(file.FileName);
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                            var image = new RestaurantImageModel
                            {
                                photo_url = "/images/" + fileName,
                                Restaurant_id = Restaurant.Restaurant_id,
                            };
                            context.RestaurantImages.Add(image);
                        }
                        
                    }
                }
            }
            return Restaurant;
        }

       

        public async Task<bool> DeleteRestaurant(string Restaurant_id)
        {
            RestaurantModel restaurant = await context.Restaurants.FindAsync(Restaurant_id);
            if (restaurant != null)
            {
                context.Restaurants.Remove(restaurant);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<RestaurantModel> GetRestaurantById(string Restaurant_id)
        {
            RestaurantModel restaurant = await context.Restaurants.FindAsync(Restaurant_id);
            if (restaurant != null)
            {
                return restaurant;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<RestaurantModel>> GetRestaurants()
        {
            return await context.Restaurants.ToListAsync();
            
        }

        public async Task<RestaurantModel> UpdateRestaurant(RestaurantModel Restaurant)
        {
            RestaurantModel res = await context.Restaurants.FindAsync(Restaurant.Restaurant_id);
            if (res != null)
            {
                res.Restaurant_name = Restaurant.Restaurant_name;
                res.Price = Restaurant.Price;
                await context.SaveChangesAsync();
                return res;
            }
            else
            {
                return null;
            }
        }

        /*public RestaurantServiceImp(IWebHostEnvironment webHostEnvironment)
        {
            _uploadFolder = Path.Combine(webHostEnvironment.ContentRootPath, "uploads");//muốn đưa vào folder nào thì ghi tên folder đó
            if (!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            string fileName = Path.GetFileName(file.FileName);
            string filePath = Path.Combine(_uploadFolder, fileName);// từ uploadfolder có thể đi đến fileName
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }*/

    }
}
