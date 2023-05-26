using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service
{
    public class TransportServiceImp: ITransportRepository
    {
        private readonly DatabaseContext databaseContext;
        private readonly ITransportRepository transportRepository;

        public TransportServiceImp(DatabaseContext databaseContext) 
        {
            this.databaseContext = databaseContext; 
        }

        public async Task<TransportModel> AddTransport(TransportModel Transport)
        {
            var tran = await databaseContext.Transports.FirstOrDefaultAsync
                (p => p.Transport_id.Equals(Transport.Transport_id));
            if (tran == null)
            {
                await databaseContext.Transports.AddAsync (Transport);
                await databaseContext.SaveChangesAsync();
                return Transport;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteTransport(string Transport_id)
        {
            TransportModel transport = await databaseContext.Transports.FindAsync(Transport_id);

            if (transport != null)
            {
                databaseContext.Transports.Remove(transport);
                await databaseContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<TransportModel> GetTransportById(string Transport_id)
        {
            TransportModel transport = await databaseContext.Transports.FindAsync (Transport_id);
            if (transport != null)
            {
                return transport;
            }
            else
            {
                return null;
            }

        }

        public async Task<IEnumerable<TransportModel>> GetTransports()
        {
           return await databaseContext.Transports.ToListAsync();
        }



        public async Task<TransportModel> UpdateTransport(TransportModel Transport)
        {
            TransportModel transport = await databaseContext.Transports.FirstOrDefaultAsync
                (t => t.Transport_id.Equals(Transport.Transport_id));
            if (transport != null)
            {
                databaseContext.Entry(Transport).State = EntityState.Modified;
                await databaseContext.SaveChangesAsync();
                return transport;
            }
            else
            {
                return null;
            }
        }
    }
}
