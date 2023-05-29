using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface ITransportTourRepository
    {
        Task<IEnumerable<TransportTourModel>> GetTransportTourById(string Transport_id);
        Task<IEnumerable<TransportTourModel>> GetByTourId(string Tour_id);
        Task<bool> AddTransportTour(List<string> Transport_ids, string Tour_Id);
        Task<bool> DeleteTransportTour(string Tour_id);
    }
}
