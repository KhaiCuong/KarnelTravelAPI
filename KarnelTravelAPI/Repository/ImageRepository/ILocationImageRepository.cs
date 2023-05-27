using KarnelTravelAPI.Model.ImageModel;

namespace KarnelTravelAPI.Repository.ImageRepository
{
    public interface ILocationImageRepository
    {
        Task<IEnumerable<TouristSpotImageModel>> GetLocationImagesAsync();
        Task<IEnumerable<string>> GetLocationImageByIdAsync(string Location_id);
        Task<bool> AddLocationImageAsync(List<IFormFile> files, string Location_id);
        Task<bool> DeleteLocationImageAsync(string Location_id);
        Task<bool> UpdateLocationImgAsync(List<IFormFile> files, string Location_id);

    }
}
