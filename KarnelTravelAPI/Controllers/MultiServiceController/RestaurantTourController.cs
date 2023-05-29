using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model.MultiServiceModel;
using KarnelTravelAPI.Repository.MultiServiceRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers.MultiServiceController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RestaurantTourController : ControllerBase
    {
        private readonly IRestaurantTourRepository _repository;
        public RestaurantTourController(IRestaurantTourRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("{Restaurant_id}")]
        public async Task<ActionResult<CustomResult<IEnumerable<RestaurantTourModel>>>> GetListByRestaurantId(string Restaurant_id)
        {
            try
            {
                var resource = await _repository.GetRestaurantTourById(Restaurant_id);
                if (resource == null)
                {
                    var response = new CustomResult<IEnumerable<RestaurantTourModel>>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<RestaurantTourModel>>(200,
                        "Get All RestaurantTour successfully", resource, null);

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<IEnumerable<string>>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }


        [HttpGet("{Tour_id}")]
        public async Task<ActionResult<CustomResult<IEnumerable<RestaurantTourModel>>>> GetListByTourId(string Tour_id)
        {
            try
            {
                var resource = await _repository.GetByTourId(Tour_id);
                if (resource == null)
                {
                    var response = new CustomResult<IEnumerable<RestaurantTourModel>>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<RestaurantTourModel>>(200,
                        "Get All RestaurantTour successfully", resource, null);

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<IEnumerable<string>>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }


        [HttpPost]
        public async Task<ActionResult<CustomResult<bool>>> PostRestaurantTour(List<string> Restaurant_ids, string Tour_Id)
        {
            try
            {
                var resources = await _repository.AddRestaurantTour(Restaurant_ids, Tour_Id);
                if (resources)
                {
                    var response = new CustomResult<bool>(200, "Resource created", true, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<bool>(404, "Not Resources Found", false, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<IEnumerable<string>>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }

        [HttpDelete("{Tour_id}")]
        public async Task<ActionResult<CustomResult<bool>>> DeleteImages(string Tour_id)
        {
            var resource = await _repository.DeleteRestaurantTour(Tour_id);
            if (resource != null)
            {

                var response = new CustomResult<bool>(200,
                    "Resource deleted successfully", resource, null);
                return Ok(response);
            }
            else
            {
                var response = new CustomResult<bool>(400,
                    "Resource not found or unable to delete", resource, null);
                return NotFound(response);
            }

        }
    }
}
