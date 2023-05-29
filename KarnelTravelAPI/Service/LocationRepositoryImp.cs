using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service
{
    public class LocationRepositoryImp : ILocationRepository
    {
        private readonly DatabaseContext _dbContext;


        public LocationRepositoryImp(DatabaseContext dbcontext)
        {
            _dbContext = dbcontext;

        }

        public async Task<LocationModel> AddLocation(LocationModel Location)
        {
            //try
            //{
            await _dbContext.Locations.AddAsync(Location);
            await _dbContext.SaveChangesAsync();
            return Location;
            //}
            //catch (Exception ex) {
            //    throw new Exception("Add error", ex);
            //} 
        }

        public async Task<bool> DeleteLocation(string Location_id)
        {
            try
            {
                LocationModel location = await _dbContext.Locations.FindAsync(Location_id);
                if (location != null)
                {
                    _dbContext.Locations.Remove(location);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Delete error!", ex);
            }
        }

        public async Task<LocationModel> GetLocationById(string Location_id)
        {
            LocationModel locationbyId = await _dbContext.Locations.FindAsync(Location_id);
            if (locationbyId != null)
            {
                return locationbyId;

            }
            else
            {
                return null;
            }

        }

        public async Task<IEnumerable<LocationModel>> GetLocations()
        {
            return await _dbContext.Locations.ToListAsync();

        }

        public async Task<LocationModel> UpdateLocation(LocationModel Location)
        {
            //vi nguoi dung khong nhap ten file truc tiep nen phai lay duoi Db Len
            var LocationDb = await _dbContext.Locations.FindAsync(Location.Location_id);

            _dbContext.Entry(Location).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Location;

        }
    }
}
