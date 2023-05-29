using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Model.MultiServiceModel;
using KarnelTravelAPI.Repository.MultiServiceRepository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service.MultiServiceModel
{
    public class AccommodationTourServiceImp : IAccommodationTourRepository
    {
        private readonly DatabaseContext _dbContext;
        public AccommodationTourServiceImp(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddAccommodationTour(List<string> Accommodation_ids, string Tour_Id)
        {
            AccommodationTourModel accommodationTour = await _dbContext.AccommodationTours.FirstOrDefaultAsync(p => p.Tour_id.Equals(Tour_Id));
            if (accommodationTour == null)
            {
                if (Accommodation_ids.Count > 0 && Accommodation_ids != null)
                {
                    foreach (var Accommodation_id in Accommodation_ids)
                    {
                        if (Accommodation_id != "" && Accommodation_id.Length != null)
                        {
                            var AccTour = new AccommodationTourModel
                            {
                                Tour_id = Tour_Id,
                                Accommodation_id = Accommodation_id,
                            };
                            await _dbContext.AccommodationTours.AddAsync(AccTour);
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
                var oldAccTour = await _dbContext.AccommodationTours.Where(a => a.Tour_id.Equals(Tour_Id)).ToListAsync();

                if (oldAccTour != null)
                {
                    foreach (var AccTour in oldAccTour)
                    {
                        if (AccTour != null)
                        {
                            _dbContext.AccommodationTours.Remove(AccTour);
                            await _dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                if (Accommodation_ids.Count > 0 && Accommodation_ids != null)
                {
                    foreach (var Accommodation_id in Accommodation_ids)
                    {
                        if (Accommodation_id != "" && Accommodation_id.Length != null)
                        {
                            var AccTour = new AccommodationTourModel
                            {
                                Tour_id = Tour_Id,
                                Accommodation_id = Accommodation_id,
                            };
                            await _dbContext.AccommodationTours.AddAsync(AccTour);
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

        public async Task<bool> DeleteAccommodationTour(string Tour_Id)
        {
            AccommodationTourModel accommodationTour = await _dbContext.AccommodationTours.FirstOrDefaultAsync(p => p.Tour_id.Equals(Tour_Id));
            if (accommodationTour != null)
            {
                var oldAccTour = await _dbContext.AccommodationTours.Where(a => a.Tour_id.Equals(Tour_Id)).ToListAsync();

                if (oldAccTour != null)
                {
                    foreach (var AccTour in oldAccTour)
                    {
                        if (AccTour != null)
                        {
                            _dbContext.AccommodationTours.Remove(AccTour);
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

        public async Task<IEnumerable<AccommodationTourModel>> GetByAccommodationId(string Accommodation_id)
        {
            var list = await _dbContext.AccommodationTours.Where(a => a.Accommodation_id.Equals(Accommodation_id)).ToListAsync();
            if(list != null && list.Count > 0)
            {
                return list;
            } else
            {
                return null;
            }

        }

        public async Task<IEnumerable<AccommodationTourModel>> GetByTourId(string Tour_id)
        {
            var list = await _dbContext.AccommodationTours.Where(a => a.Tour_id.Equals(Tour_id)).ToListAsync();
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
