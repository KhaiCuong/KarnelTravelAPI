namespace KarnelTravelAPI.Repository.ImageRepository
{
    public interface IRestaurantImageRepository
    {
        Task<string> UploadFile(IFormFile file);

    }
}
