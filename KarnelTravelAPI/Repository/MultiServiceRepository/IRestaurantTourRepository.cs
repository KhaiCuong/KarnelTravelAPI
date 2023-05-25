using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface IRestaurantTourRepository
    {
        Task<IEnumerable<RestaurantTourModel>> GetRestaurantTourById(string Restaurant_id);
        Task<RestaurantTourModel> AddRestaurantTour(RestaurantTourModel Restaurant);
        Task<RestaurantTourModel> DeleteRestaurantTour(RestaurantTourModel Restaurant);
    }
}
