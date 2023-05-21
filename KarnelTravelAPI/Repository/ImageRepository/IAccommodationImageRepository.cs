namespace KarnelTravelAPI.Repository.ImageRepository
{
    public interface IAccommodationImageRepository
    {
        Task<string> UploadFile(IFormFile file);

    }
}
