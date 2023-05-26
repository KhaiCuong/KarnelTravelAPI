using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _repository;
        public RestaurantController(IRestaurantRepository repository)
        {
            this._repository = repository;
        }
        
        [HttpGet]
        public async Task<ActionResult<CustomResult<IEnumerable<RestaurantModel>>>> GetRestaurants()
        {
            try
            {
                var resources = await _repository.GetRestaurants();
                if (resources != null && resources.Any())
                {
                    var response = new CustomResult<IEnumerable<RestaurantModel>>(200, "Resources found", resources, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<RestaurantModel>>(404, "Not Resources Found", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<RestaurantModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }

        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomResult<RestaurantModel>>> GetRestaurantById(string id)
        {
            try
            {
                var resource = await _repository.GetRestaurantById(id);
                if (resource == null)
                {
                    var response = new CustomResult<RestaurantModel>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<RestaurantModel>(200,
                        "Get employee successfully", resource, null);

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<RestaurantModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }

        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomResult<string>>> DeleteRestaurant(string id)
        {
            bool resourceDeleted = false;
            var resource = await _repository.GetRestaurantById(id);

            if (resource != null)
            {
                resourceDeleted = await _repository.DeleteRestaurant(id);
            }
            if (resourceDeleted)
            {

                var response = new CustomResult<string>(200,
                    "Resource deleted successfully", null, null);
                return Ok(response);
            }
            else
            {
                var response = new CustomResult<string>(200,
                    "Resource not found or unable to delete", null, null);
                return NotFound(response);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<CustomResult<RestaurantModel>>> AddRestaurant
          ([FromForm] RestaurantModel Restaurant)
        {
            try
            {
                var resource = await _repository.AddRestaurant(Restaurant);
                if (resource != null)
                {
                    var response = new CustomResult<RestaurantModel>(201, "Resource created",
                        Restaurant, null);
                    return CreatedAtAction(nameof(GetRestaurantById), new { id = Restaurant.Restaurant_id },
                        Restaurant);

                }
                else
                {
                    var response = new CustomResult<RestaurantModel>(400,
                        "Unable to create resource", null, null);
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<RestaurantModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }
        
        [HttpPut("{Restaurant_id}")]
        public async Task<ActionResult<CustomResult<RestaurantModel>>> UpdateRestaurant
         ([FromForm] RestaurantModel Restaurant)
        {
            try
            {
                var resource = await _repository.UpdateRestaurant(Restaurant);
                if (resource != null)
                {
                    var response = new CustomResult<RestaurantModel>(200,
                        "update employee successfully", Restaurant, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<RestaurantModel>(404,
                        "No employee to update", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<RestaurantModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }
    }
}
