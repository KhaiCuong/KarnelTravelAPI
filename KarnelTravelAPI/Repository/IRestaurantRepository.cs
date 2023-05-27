using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<RestaurantModel>> GetRestaurants();
        Task<RestaurantModel> GetRestaurantById(string Restaurant_id);
        // test push nhánh
        Task<RestaurantModel> AddRestaurant(RestaurantModel Restaurant);
        Task<RestaurantModel> UpdateRestaurant(RestaurantModel Restaurant);
        Task<bool> DeleteRestaurant(string Restaurant_id);
    }
}
