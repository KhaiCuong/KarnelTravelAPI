using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Repository;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace KarnelTravelAPI.Service
{
    public class TouristSpotServiceImp : ITouristSpotRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ITouristSpotImageRepository _touristSpotImage;

        public TouristSpotServiceImp(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<TouristSpotModel> AddTouristSpot(TouristSpotModel TouristSpot)
        {
            var spot = await _databaseContext.TouristSpots.FirstOrDefaultAsync(p => p.TouristSpot_id.Equals(TouristSpot.TouristSpot_id));
            if (spot == null)
            {
                await _databaseContext.TouristSpots.AddAsync(TouristSpot);
                await _databaseContext.SaveChangesAsync();
                return TouristSpot;

            } else
                {
                    return null;
                }
             }

        public async Task<bool> DeleteTouristSpot(string TouristSpot_id)
        {
            TouristSpotModel spot = await _databaseContext.TouristSpots.FindAsync(TouristSpot_id);


            if (spot != null)
            {
                _databaseContext.TouristSpots.Remove(spot);
                await _databaseContext.SaveChangesAsync();
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<TouristSpotModel> GetTouristSpotById(string TouristSpot_id)
        {
            TouristSpotModel spot = await _databaseContext.TouristSpots.FindAsync(TouristSpot_id);

            if (spot != null)
            {

                return spot; 
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<TouristSpotModel>> GetTouristSpots()
        {  
            return await _databaseContext.TouristSpots.ToListAsync();
        }

        public async Task<TouristSpotModel> UpdateTouristSpot(TouristSpotModel TouristSpot)
        {
            TouristSpotModel spot = await _databaseContext.TouristSpots.FirstOrDefaultAsync(p => p.TouristSpot_id.Equals(TouristSpot.TouristSpot_id));
            if (spot != null)
            {
                _databaseContext.Entry(TouristSpot).State = EntityState.Modified;
                await _databaseContext.SaveChangesAsync();
                return spot;
            }
            else
            {
                return null;
            }
        }
    }
}
