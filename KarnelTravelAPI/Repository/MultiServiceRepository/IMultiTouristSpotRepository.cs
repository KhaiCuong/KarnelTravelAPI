using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface IMultiTouristSpotRepository
    {
        Task<IEnumerable<MultiTouristSpotModel>> GetMultiTouristSpotById(string TouristSpot_id);
        Task<MultiTouristSpotModel> AddMultiTouristSpot(MultiTouristSpotModel TouristSpot);
        Task<MultiTouristSpotModel> DeleteMultiTouristSpot(MultiTouristSpotModel TouristSpot);
    }
}
