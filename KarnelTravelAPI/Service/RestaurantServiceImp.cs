using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service
{
    public class RestaurantServiceImp : IRestaurantRepository
    {
        private readonly string _uploadFolder;
        private DatabaseContext context;
        public RestaurantServiceImp(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<RestaurantModel> AddRestaurant(RestaurantModel Restaurant)
        {
            var res = context.Restaurants.FirstOrDefault(p => p.Restaurant_name.Equals(Restaurant.Restaurant_name));
            if (res == null)
            {
                await context.Restaurants.AddAsync(Restaurant);
                await context.SaveChangesAsync();
                return Restaurant;
            }
            else
            {
                return null;
            }
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

        public RestaurantServiceImp(IWebHostEnvironment webHostEnvironment)
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
        }

    }
}
