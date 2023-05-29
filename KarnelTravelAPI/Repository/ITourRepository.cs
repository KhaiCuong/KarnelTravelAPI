using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface ITourRepository
    {
        Task<IEnumerable<TourModel>> GetTours();
        Task<TourModel> GetTourById(string Tour_id);
        Task<TourModel> AddTour(TourModel Tour);
        Task<TourModel> UpdateTour(TourModel Tour);
        Task<TourModel> UpdateStatus_tour(string Tour_id);
        Task<bool> DeleteTour(string Tour_id);
    }
}
