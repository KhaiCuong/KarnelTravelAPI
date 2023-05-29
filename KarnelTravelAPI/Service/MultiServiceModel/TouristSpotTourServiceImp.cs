using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.MultiServiceModel;
using KarnelTravelAPI.Repository.MultiServiceRepository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service.MultiServiceModel
{
    public class TouristSpotTourServiceImp : ITouristSpotTourRepository
    {
        private readonly DatabaseContext _dbContext;
        public TouristSpotTourServiceImp(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddTouristSpotTour(List<string> TouristSpot_ids, string Tour_Id)
        {
            TouristSpotTourModel touristSpotTours = await _dbContext.TouristSpotTours.FirstOrDefaultAsync(p => p.Tour_id.Equals(Tour_Id));
            if (touristSpotTours == null)
            {
                if (TouristSpot_ids.Count > 0 && TouristSpot_ids != null)
                {
                    foreach (var TouristSpot_id in TouristSpot_ids)
                    {
                        if (TouristSpot_id != "" && TouristSpot_id.Length != null)
                        {
                            var AccTour = new TouristSpotTourModel
                            {
                                Tour_id = Tour_Id,
                                TouristSpot_id = TouristSpot_id,
                            };
                            await _dbContext.TouristSpotTours.AddAsync(AccTour);
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
                var oldTourSpTour = await _dbContext.TouristSpotTours.Where(a => a.Tour_id.Equals(Tour_Id)).ToListAsync();

                if (oldTourSpTour != null)
                {
                    foreach (var AccTour in oldTourSpTour)
                    {
                        if (AccTour != null)
                        {
                            _dbContext.TouristSpotTours.Remove(AccTour);
                            await _dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                if (TouristSpot_ids.Count > 0 && TouristSpot_ids != null)
                {
                    foreach (var TouristSpot_id in TouristSpot_ids)
                    {
                        if (TouristSpot_id != "" && TouristSpot_id.Length != null)
                        {
                            var AccTour = new TouristSpotTourModel
                            {
                                Tour_id = Tour_Id,
                                TouristSpot_id = TouristSpot_id,
                            };
                            await _dbContext.TouristSpotTours.AddAsync(AccTour);
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

        public async Task<bool> DeleteTouristSpotTour(string Tour_id)
        {
            TouristSpotTourModel touristSpotTours = await _dbContext.TouristSpotTours.FirstOrDefaultAsync(p => p.Tour_id.Equals(Tour_id));
            if (touristSpotTours != null)
            {
                var oldTourSpTour = await _dbContext.TouristSpotTours.Where(a => a.Tour_id.Equals(Tour_id)).ToListAsync();

                if (oldTourSpTour != null)
                {
                    foreach (var AccTour in oldTourSpTour)
                    {
                        if (AccTour != null)
                        {
                            _dbContext.TouristSpotTours.Remove(AccTour);
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

        public async Task<IEnumerable<TouristSpotTourModel>> GetByTourId(string Tour_id)
        {
            var list = await _dbContext.TouristSpotTours.Where(a => a.Tour_id.Equals(Tour_id)).ToListAsync();
            if (list != null && list.Count > 0)
            {
                return list;
            }
            else
            {
                return null;
            }

        }

        public async Task<IEnumerable<TouristSpotTourModel>> GetTouristSpotTourById(string TouristSpot_id)
        {
            var list = await _dbContext.TouristSpotTours.Where(a => a.TouristSpot_id.Equals(TouristSpot_id)).ToListAsync();
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
