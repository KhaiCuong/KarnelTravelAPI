﻿using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantRepository RestaurantRepository;
        public RestaurantController(IRestaurantRepository restaurantRepository)
        {
            this.RestaurantRepository = restaurantRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<RestaurantModel>> GetRestaurants()
        {
            var res = await RestaurantRepository.GetRestaurants();
            return res;
        }
        
        [HttpGet("{id}")]
        public async Task<RestaurantModel> GetRestaurantById(string Restaurant_id)
        {
            var res = await RestaurantRepository.GetRestaurantById(Restaurant_id);
            return res;
        }
        
        [HttpDelete("{id}")]
        public async Task<bool> DeleteRestaurant(string Restaurant_id)
        {
            return await RestaurantRepository.DeleteRestaurant(Restaurant_id);
        }
        
        [HttpPost]
        public async Task<RestaurantModel> AddRestaurant(RestaurantModel Restaurant)
        {
            return await RestaurantRepository.AddRestaurant(Restaurant);
        }
        
        [HttpPut("{id}")]
        public async Task<RestaurantModel> UpdateRestaurant(RestaurantModel Restaurant)
        {
            return await RestaurantRepository.UpdateRestaurant(Restaurant);
        }
    }
}
