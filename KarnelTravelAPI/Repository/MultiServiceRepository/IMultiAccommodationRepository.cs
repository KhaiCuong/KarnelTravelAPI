using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface IMultiAccommodationRepository
    {
        Task<IEnumerable<AccommodationTourModel>> GetMultiAccommodationById(string Accommodation_id);
        Task<AccommodationTourModel> AddMultiAccommodation(AccommodationTourModel Accommodation);
        Task<AccommodationTourModel> DeleteMultiAccommodation(AccommodationTourModel Accommodation);

    }
}
