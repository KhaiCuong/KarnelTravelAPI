using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface ITouristSpotRepository
    {
        Task<IEnumerable<TouristSpotModel>> GetTouristSpots();
        Task<TouristSpotModel> GetTouristSpotById(string TouristSpot_id);
        Task<TouristSpotModel> AddTouristSpot(TouristSpotModel TouristSpot);
        Task<TouristSpotModel> UpdateTouristSpot(TouristSpotModel TouristSpot);
        Task<bool> DeleteTouristSpot(string TouristSpot_id);
    }
}
