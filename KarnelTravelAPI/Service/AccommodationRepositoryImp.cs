using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Repository;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service
{
    public class AccommodationRepositoryImp : IAccommodationRepository
    {
        private readonly DatabaseContext _dbContext;

        public AccommodationRepositoryImp(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AccommodationModel> AddAccommodation(AccommodationModel Accommodation)
        {
            try
            {
                AccommodationModel accommodation = await _dbContext.Accommodations.FirstOrDefaultAsync(a=>a.Accommodation_id.Equals(Accommodation.Accommodation_id));
                if(accommodation == null)
                {
                    await _dbContext.Accommodations.AddAsync(Accommodation);
                    await _dbContext.SaveChangesAsync();
                    return Accommodation;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAccommodation(string Accommodation_id)
        {
            AccommodationModel accommodation = await _dbContext.Accommodations.FirstOrDefaultAsync(a => a.Accommodation_id.Equals(Accommodation_id));
            if(accommodation != null)
            {
                _dbContext.Accommodations.Remove(accommodation);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<AccommodationModel> GetAccommodationById(string Accommodation_id)
        {
            AccommodationModel accommodation = await _dbContext.Accommodations.FindAsync(Accommodation_id);
            if(accommodation != null)
            {
                return accommodation;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<AccommodationModel>> GetAccommodations()
        {
            return await _dbContext.Accommodations.ToListAsync();
        }

        public async Task<AccommodationModel> UpdateAccommodation(AccommodationModel Accommodation)
        {
            AccommodationModel accommodation = await _dbContext.Accommodations.FindAsync(Accommodation.Accommodation_id);
            if(accommodation != null)
            {
                _dbContext.Entry(Accommodation).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return accommodation;
            }
            else
            {
                return null;
            }
        }
    }
}
