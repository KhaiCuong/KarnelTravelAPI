using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.MultiServiceModel;
using KarnelTravelAPI.Repository.MultiServiceRepository;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAPI.Service.MultiServiceModel
{
    public class RestaurantTourServiceImp : IRestaurantTourRepository
    {
        private readonly DatabaseContext _dbContext;
        public RestaurantTourServiceImp(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddRestaurantTour(List<string> Restaurant_ids, string Tour_Id)
        {
            RestaurantTourModel restaurantTour = await _dbContext.RestaurantTours.FirstOrDefaultAsync(p => p.Tour_id.Equals(Tour_Id));
            if (restaurantTour == null)
            {
                if (Restaurant_ids.Count > 0 && Restaurant_ids != null)
                {
                    foreach (var Restaurant_id in Restaurant_ids)
                    {
                        if (Restaurant_id != "" && Restaurant_id.Length != null)
                        {
                            var AccTour = new RestaurantTourModel
                            {
                                Tour_id = Tour_Id,
                                Restaurant_id = Restaurant_id,
                            };
                            await _dbContext.RestaurantTours.AddAsync(AccTour);
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
                var oldResTour = await _dbContext.RestaurantTours.Where(a => a.Tour_id.Equals(Tour_Id)).ToListAsync();

                if (oldResTour != null)
                {
                    foreach (var AccTour in oldResTour)
                    {
                        if (AccTour != null)
                        {
                            _dbContext.RestaurantTours.Remove(AccTour);
                            await _dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                if (Restaurant_ids.Count > 0 && Restaurant_ids != null)
                {
                    foreach (var Restaurant_id in Restaurant_ids)
                    {
                        if (Restaurant_id != "" && Restaurant_id.Length != null)
                        {
                            var AccTour = new RestaurantTourModel
                            {
                                Tour_id = Tour_Id,
                                Restaurant_id = Restaurant_id,
                            };
                            await _dbContext.RestaurantTours.AddAsync(AccTour);
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

        public async Task<bool> DeleteRestaurantTour(string Tour_Id)
        {
            RestaurantTourModel restaurantTour = await _dbContext.RestaurantTours.FirstOrDefaultAsync(p => p.Tour_id.Equals(Tour_Id));
            if (restaurantTour != null)
            {
                var oldResTour = await _dbContext.RestaurantTours.Where(a => a.Tour_id.Equals(Tour_Id)).ToListAsync();

                if (oldResTour != null)
                {
                    foreach (var AccTour in oldResTour)
                    {
                        if (AccTour != null)
                        {
                            _dbContext.RestaurantTours.Remove(AccTour);
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

        public async Task<IEnumerable<RestaurantTourModel>> GetByTourId(string Tour_id)
        {
            var list = await _dbContext.RestaurantTours.Where(a => a.Tour_id.Equals(Tour_id)).ToListAsync();
            if (list != null && list.Count > 0)
            {
                return list;
            }
            else
            {
                return null;
            }

        }

        public async Task<IEnumerable<RestaurantTourModel>> GetRestaurantTourById(string Restaurant_id)
        {
            var list = await _dbContext.RestaurantTours.Where(a => a.Restaurant_id.Equals(Restaurant_id)).ToListAsync();
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
