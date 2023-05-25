using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface IAccommodationRepository
    {
        
        Task<IEnumerable<AccommodationModel>> GetAccommodations();
        Task<AccommodationModel> GetAccommodationById(string Accommodation_id);
        Task<AccommodationModel> AddAccommodation(AccommodationModel Accommodation, ICollection<IFormFile>? files);
        Task<AccommodationModel> UpdateAccommodation(AccommodationModel Accommodation, ICollection<IFormFile>? files);
        Task<bool> DeleteAccommodation(string Accommodation_id);
    }
}
