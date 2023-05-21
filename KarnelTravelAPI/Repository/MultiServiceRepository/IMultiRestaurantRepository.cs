using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface IMultiRestaurantRepository
    {
        Task<IEnumerable<MultiRestaurantModel>> GetMultiRestaurantById(string Restaurant_id);
        Task<MultiRestaurantModel> AddMultiRestaurant(MultiRestaurantModel Restaurant);
        Task<MultiRestaurantModel> DeleteMultiRestaurant(MultiRestaurantModel Restaurant);
    }
}
