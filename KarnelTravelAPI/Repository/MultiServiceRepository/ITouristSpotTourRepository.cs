using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface ITouristSpotTourRepository
    {
        Task<IEnumerable<TouristSpotTourModel>> GetTouristSpotTourById(string TouristSpot_id);
        Task<TouristSpotTourModel> AddTouristSpotTour(TouristSpotTourModel TouristSpot);
        Task<TouristSpotTourModel> DeleteTouristSpotTour(TouristSpotTourModel TouristSpot);
    }
}
