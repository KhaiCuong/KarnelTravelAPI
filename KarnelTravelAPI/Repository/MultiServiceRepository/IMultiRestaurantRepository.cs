using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface IMultiRestaurantRepository
    {
        Task<IEnumerable<RestaurantTourModel>> GetMultiRestaurantById(string Restaurant_id);
        Task<RestaurantTourModel> AddMultiRestaurant(RestaurantTourModel Restaurant);
        Task<RestaurantTourModel> DeleteMultiRestaurant(RestaurantTourModel Restaurant);
    }
}
