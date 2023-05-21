using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface ITourRepository
    {
        Task<IEnumerable<TourModel>> GetTours();
        Task<TourModel> GetTourById(int Tour_id);
        Task<TourModel> AddTour(TourModel Tour);
        Task<TourModel> UpdateTour(TourModel Tour);
        Task<TourModel> UpdateQuantityById(int Tour_id);
        Task<bool> DeleteTour(int Tour_id);
    }
}
