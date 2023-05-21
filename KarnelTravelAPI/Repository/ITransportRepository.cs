using KarnelTravelAPI.Model;

namespace KarnelTravelAPI.Repository
{
    public interface ITransportRepository
    {
        Task<IEnumerable<TransportModel>> GetTransports();
        Task<TransportModel> GetTransportById(string Transport_id);
        Task<TransportModel> AddTransport(TransportModel Transport);
        Task<TransportModel> UpdateTransport(TransportModel Transport);
        Task<bool> DeleteTransport(string Transport_id);
    }
}
