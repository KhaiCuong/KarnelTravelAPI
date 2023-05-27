using KarnelTravelAPI.Model.ImageModel;

namespace KarnelTravelAPI.Repository.ImageRepository
{
    public interface IRestaurantImageRepository
    {
        Task<bool> DeleteImage(string Restaurant_id);
        Task<bool> AddImage(List<IFormFile> files, string Restaurant_id);
        Task<IEnumerable<RestaurantImageModel>> AllImgs();
        Task<IEnumerable<string>> GetListImgById(string Restaurant_id);
        Task<bool> UpdateImg(List<IFormFile> files, string Restaurant_id);

    }
}
