using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.ImageModel;

namespace KarnelTravelAPI.Repository.ImageRepository
{
    public interface ITouristSpotImageRepository
    {
        Task<bool> DeleteImage(string TouristSpot_Id);
        Task<bool> AddImage(List<IFormFile> files, string TouristSpot_Id);
        Task<IEnumerable<TouristSpotImageModel>> AllImgs();
        Task<IEnumerable<string>> GetListImgById(string TouristSpot_Id);
        Task<bool> UpdateImg(List<IFormFile> files, string TouristSpot_Id);

    }
}
