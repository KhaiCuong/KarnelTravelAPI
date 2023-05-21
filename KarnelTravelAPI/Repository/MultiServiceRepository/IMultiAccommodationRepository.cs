using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface IMultiAccommodationRepository
    {
        Task<IEnumerable<MultiAccommodationModel>> GetMultiAccommodationById(string Accommodation_id);
        Task<MultiAccommodationModel> AddMultiAccommodation(MultiAccommodationModel Accommodation);
        Task<MultiAccommodationModel> DeleteMultiAccommodation(MultiAccommodationModel Accommodation);

    }
}
