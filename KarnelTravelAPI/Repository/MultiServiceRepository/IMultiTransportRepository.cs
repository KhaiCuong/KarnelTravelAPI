using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface IMultiTransportRepository
    {
        Task<IEnumerable<TransportTourModel>> GetMultiTransportById(string Transport_id);
        Task<TransportTourModel> AddMultiTransport(TransportTourModel Transport);
        Task<TransportTourModel> DeleteMultiTransport(TransportTourModel Transport);
    }
}
