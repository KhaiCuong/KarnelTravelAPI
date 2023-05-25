using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface ITransportTourRepository
    {
        Task<IEnumerable<TransportTourModel>> GetTransportTourById(string Transport_id);
        Task<TransportTourModel> AddTransportTour(TransportTourModel Transport);
        Task<TransportTourModel> DeleteTransportTour(TransportTourModel Transport);
    }
}
