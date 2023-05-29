using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface ITouristSpotTourRepository
    {
        Task<IEnumerable<TouristSpotTourModel>> GetTouristSpotTourById(string TouristSpot_id);
        Task<IEnumerable<TouristSpotTourModel>> GetByTourId(string Tour_id);
        Task<bool> AddTouristSpotTour(List<string> TouristSpot_ids, string Tour_Id);
        Task<bool> DeleteTouristSpotTour(string Tour_id);
    }
}
