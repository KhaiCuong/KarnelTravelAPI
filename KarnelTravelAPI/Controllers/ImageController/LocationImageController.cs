using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers.ImageController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationImageController : ControllerBase
    {
        private readonly ILocationImageRepository _repository;
        public LocationImageController(ILocationImageRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<CustomResult<IEnumerable<string>>>> GetLocationImagesByLocationId(string id)
        {
            try
            {
                var resource = await _repository.GetLocationImageByIdAsync(id);
                if (resource == null)
                {
                    var response = new CustomResult<IEnumerable<string>>(404,
                        "Resource not found or unable to get by id", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<string>>(200,
                        "Get Images by Location_id successfully", resource, null);

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

        [HttpPut("{id}")] // id = Location_id
        public async Task<ActionResult<CustomResult<bool>>> UpdateLocationImageById(List<IFormFile> files, string id)
        {
            try
            {
                var resources = await _repository.UpdateLocationImgAsync(files, id);
                if (resources)
                {
                    var response = new CustomResult<IEnumerable<TouristSpotModel>>(200, "Location image updated", null, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<TouristSpotModel>>(404, "No Resources Found", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<TouristSpotModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomResult<bool>>> PostLocationImages(List<IFormFile> files, string Location_id)
        {
            try
            {
                var resources = await _repository.AddLocationImageAsync(files, Location_id);
                if (resources)
                {
                    var response = new CustomResult<IEnumerable<TouristSpotModel>>(200, "Location Image created", null, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<TouristSpotModel>>(404, "Not Resources Found", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<TouristSpotModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomResult<string>>> DeleteLocationImage(string id)
        {
            bool resourceDeleted = false;
            var resource = await _repository.DeleteLocationImageAsync(id);
            if (resource != null)
            {

                var response = new CustomResult<string>(200,
                    "Location Image deleted successfully", null, null);
                return Ok(response);
            }
            else
            {
                var response = new CustomResult<string>(200,
                    "Resource not found or unable to delete", null, null);
                return NotFound(response);
            }

        }

    }
}
