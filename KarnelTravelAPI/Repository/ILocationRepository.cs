using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface ILocationRepository
    {

        Task<IEnumerable<LocationModel>> GetLocations();
        Task<LocationModel> GetLocationById(string Location_id);
        Task<LocationModel> AddLocation(LocationModel Location);
        Task<LocationModel> UpdateLocation(LocationModel Location);
        Task<bool> DeleteLocation(string Location_id);
    }
}
