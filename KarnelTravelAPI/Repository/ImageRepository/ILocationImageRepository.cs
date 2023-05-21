namespace KarnelTravelAPI.Repository.ImageRepository
{
    public interface ILocationImageRepository
    {
        Task<string> UploadFile(IFormFile file);

    }
}
