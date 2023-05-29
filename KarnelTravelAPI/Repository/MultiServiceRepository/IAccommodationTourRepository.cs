using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface IAccommodationTourRepository
    {
        Task<IEnumerable<AccommodationTourModel>> GetByAccommodationId(string Accommodation_id);
        Task<IEnumerable<AccommodationTourModel>> GetByTourId(string Tour_id);
        Task<bool> AddAccommodationTour(List<string> Accommodation_ids, string Tour_Id);
        Task<bool> DeleteAccommodationTour(string Tour_id);

    }
}
