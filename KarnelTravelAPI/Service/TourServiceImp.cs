using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service
{
    public class TourServiceImp : ITourRepository
    {
        private readonly DatabaseContext _dbContext;

        public TourServiceImp(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<TourModel> AddTour(TourModel Tour)
        {
 
            TourModel tour = await _dbContext.Tours.FirstOrDefaultAsync(a => a.Tour_id.Equals(Tour.Tour_id));
            if (tour == null)
            {
                await _dbContext.Tours.AddAsync(Tour);
                await _dbContext.SaveChangesAsync();
                return Tour;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteTour(int Tour_id)
        {

            TourModel tour = await _dbContext.Tours.FindAsync(Tour_id);


            if (tour != null)
            {
                _dbContext.Tours.Remove(tour);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<TourModel> GetTourById(int Tour_id)
        {
            TourModel tour = await _dbContext.Tours.FindAsync(Tour_id);


            if (tour != null)
            {
                
                return tour;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<TourModel>> GetTours()
        {
            return await _dbContext.Tours.ToListAsync();
        }

        public async Task<TourModel> UpdateStatus_tour(int Tour_id)
        {
            TourModel tour = await _dbContext.Tours.FindAsync(Tour_id);
            if(tour != null)
            {
                var status = !tour.Status_tour;
                tour.Status_tour = status;
                _dbContext.Update(tour);
                await _dbContext.SaveChangesAsync();
                return tour;

            }
            else
            {
                return null;
            }
        }

        public async Task<TourModel> UpdateTour(TourModel Tour)
        {
            TourModel tour = await _dbContext.Tours.FirstOrDefaultAsync(a => a.Tour_id.Equals(Tour.Tour_id));
            if (tour != null)
            {
                _dbContext.Entry(Tour).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return tour;
            }
            else
            {
                return null;
            }
        }
    }
}
