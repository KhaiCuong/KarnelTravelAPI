using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.ImageModel;

namespace KarnelTravelAPI.Repository.ImageRepository
{
    public interface IAccommodationImageRepository
    {
        // Task<AccommodationModel> UploadFile(List<IFormFile> files);
        Task<IEnumerable<AccommodationImageModel>> GetAllAccommodationImages();
        Task<IEnumerable<string>> GetAccommodationImage(string Accommodation_Id);
        Task<AccommodationImageModel> AddAccommodationImages(List<IFormFile> files, string Accommodation_Id);
        Task<AccommodationImageModel> UpdateAccommodationImage(List<IFormFile> files, string Accommodation_Id);
        Task<bool> DeleteAccommodationImage(string Accommodation_Id);
    }
}
