using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface IRestaurantTourRepository
    {
        Task<IEnumerable<RestaurantTourModel>> GetRestaurantTourById(string Restaurant_id);
        Task<IEnumerable<RestaurantTourModel>> GetByTourId(string Tour_id);
        Task<bool> AddRestaurantTour(List<string> Restaurant_ids, string Tour_Id);
        Task<bool> DeleteRestaurantTour(string Tour_id);
    }
}
