using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository.ImageRepository
{
    public interface IAccommodationImageRepository
    {
        Task<AccommodationModel> UploadFile(List<IFormFile> files);

    }
}
