using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Repository;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace KarnelTravelAPI.Service
{
    public class RestaurantServiceImp : IRestaurantRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RestaurantServiceImp(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<RestaurantModel> AddRestaurant(RestaurantModel restaurant)
        {
            var res = await _databaseContext.Restaurants.FirstOrDefaultAsync(r => r.Restaurant_id.Equals(restaurant.Restaurant_id));
            if (res == null)
            {
                await _databaseContext.Restaurants.AddAsync(restaurant);
                await _databaseContext.SaveChangesAsync();
                return restaurant;

            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteRestaurant(string Restaurant_id)
        {
            RestaurantModel res = await _databaseContext.Restaurants.FindAsync(Restaurant_id);


            if (res != null)
            {
                _databaseContext.Restaurants.Remove(res);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<RestaurantModel> GetRestaurantById(string Restaurant_id)
        {            RestaurantModel res = await _databaseContext.Restaurants.FindAsync(Restaurant_id);
            if (res != null)
            {

                return res;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<RestaurantModel>> GetRestaurants()
        {
            return await _databaseContext.Restaurants.ToListAsync();
        }

        public async Task<RestaurantModel> UpdateRestaurant(RestaurantModel Restaurant)
        {
            RestaurantModel res = await _databaseContext.Restaurants.FirstOrDefaultAsync(r => r.Restaurant_id.Equals(Restaurant.Restaurant_id));
            if (res != null)
            {
                _databaseContext.Entry(Restaurant).State = EntityState.Modified;
                await _databaseContext.SaveChangesAsync();
                return Restaurant;
            }
            else
            {
                return null;
            }
        }
    }
}
