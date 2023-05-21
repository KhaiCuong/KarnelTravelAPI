using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface IAccommodationRepository
    {
        
        Task<IEnumerable<AccommodationModel>> GetAccommodations();
        Task<AccommodationModel> GetAccommodationById(string Accommodation_id);
        Task<AccommodationModel> AddAccommodation(AccommodationModel Accommodation);
        Task<AccommodationModel> UpdateAccommodation(AccommodationModel Accommodation);
        Task<bool> DeleteAccommodation(string Accommodation_id);
    }
}
