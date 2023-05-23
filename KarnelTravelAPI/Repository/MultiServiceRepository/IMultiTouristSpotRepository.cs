using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface IMultiTouristSpotRepository
    {
        Task<IEnumerable<TouristSpotTourModel>> GetMultiTouristSpotById(string TouristSpot_id);
        Task<TouristSpotTourModel> AddMultiTouristSpot(TouristSpotTourModel TouristSpot);
        Task<TouristSpotTourModel> DeleteMultiTouristSpot(TouristSpotTourModel TouristSpot);
    }
}
