using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface IAccommodationTourRepository
    {
        Task<IEnumerable<AccommodationTourModel>> GetAccommodationTourById(string Accommodation_id);
        Task<AccommodationTourModel> AddAccommodationTour(AccommodationTourModel Accommodation);
        Task<AccommodationTourModel> DeleteAccommodationTour(AccommodationTourModel Accommodation);

    }
}
