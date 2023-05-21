namespace KarnelTravelAPI.Repository.ImageRepository
{
    public interface ITouristSpotImageRepository
    {
        Task<string> UploadFile(IFormFile file);

    }
}
