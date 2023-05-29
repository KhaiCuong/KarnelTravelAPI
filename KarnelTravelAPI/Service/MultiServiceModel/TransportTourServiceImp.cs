using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.MultiServiceModel;
using KarnelTravelAPI.Repository.MultiServiceRepository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service.MultiServiceModel
{
    public class TransportTourServiceImp : ITransportTourRepository
    {
        private readonly DatabaseContext _dbContext;
        public TransportTourServiceImp(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddTransportTour(List<string> Transport_ids, string Tour_Id)
        {
            TransportTourModel transportTour = await _dbContext.TransportTours.FirstOrDefaultAsync(p => p.Tour_id.Equals(Tour_Id));
            if (transportTour == null)
            {
                if (Transport_ids.Count > 0 && Transport_ids != null)
                {
                    foreach (var Transport_id in Transport_ids)
                    {
                        if (Transport_id != "" && Transport_id.Length != null)
                        {
                            var AccTour = new TransportTourModel
                            {
                                Tour_id = Tour_Id,
                                Transport_id = Transport_id,
                            };
                            await _dbContext.TransportTours.AddAsync(AccTour);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                var oldTranTour = await _dbContext.TransportTours.Where(a => a.Tour_id.Equals(Tour_Id)).ToListAsync();

                if (oldTranTour != null)
                {
                    foreach (var AccTour in oldTranTour)
                    {
                        if (AccTour != null)
                        {
                            _dbContext.TransportTours.Remove(AccTour);
                            await _dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                if (Transport_ids.Count > 0 && Transport_ids != null)
                {
                    foreach (var Transport_id in Transport_ids)
                    {
                        if (Transport_id != "" && Transport_id.Length != null)
                        {
                            var AccTour = new TransportTourModel
                            {
                                Tour_id = Tour_Id,
                                Transport_id = Transport_id,
                            };
                            await _dbContext.TransportTours.AddAsync(AccTour);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }

                return true;
            }
        }

        public async Task<bool> DeleteTransportTour(string tour_id)
        {
            TransportTourModel transportTour = await _dbContext.TransportTours.FirstOrDefaultAsync(p => p.Tour_id.Equals(tour_id));
            if (transportTour != null)
            {
                var oldTranTour = await _dbContext.TransportTours.Where(a => a.Tour_id.Equals(tour_id)).ToListAsync();

                if (oldTranTour != null)
                {
                    foreach (var AccTour in oldTranTour)
                    {
                        if (AccTour != null)
                        {
                            _dbContext.TransportTours.Remove(AccTour);
                            await _dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<TransportTourModel>> GetByTourId(string Tour_id)
        {
            var list = await _dbContext.TransportTours.Where(a => a.Tour_id.Equals(Tour_id)).ToListAsync();
            if (list != null && list.Count > 0)
            {
                return list;
            }
            else
            {
                return null;
            }

        }

        public async Task<IEnumerable<TransportTourModel>> GetTransportTourById(string Transport_id)
        {
            var list = await _dbContext.TransportTours.Where(a => a.Transport_id.Equals(Transport_id)).ToListAsync();
            if (list != null && list.Count > 0)
            {
                return list;
            }
            else
            {
                return null;
            }
        }
    }
}
