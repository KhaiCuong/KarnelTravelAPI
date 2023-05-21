using KarnelTravelAPI.Model.MultiServiceModel;

namespace KarnelTravelAPI.Repository.MultiServiceRepository
{
    public interface IMultiTransportRepository
    {
        Task<IEnumerable<MultiTransportModel>> GetMultiTransportById(string Transport_id);
        Task<MultiTransportModel> AddMultiTransport(MultiTransportModel Transport);
        Task<MultiTransportModel> DeleteMultiTransport(MultiTransportModel Transport);
    }
}
