using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using KarnelTravelAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {
        private readonly IAccommodationRepository _accommodationService;

        public AccommodationController(IAccommodationRepository accommodationService)
        {
            _accommodationService = accommodationService;
        }

        [HttpGet]
        public async Task<ActionResult<CustomResult<IEnumerable<AccommodationModel>>>> GetAccommodations()
        {
            try
            {
                var resources = await _accommodationService.GetAccommodations();
                if(resources != null && resources.Any())
                {
                    var response = new CustomResult<IEnumerable<AccommodationModel>>(200, "Resources Found", resources, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<AccommodationModel>>(404, "No resource Found", null, null);
                    return (response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<AccommodationModel>()
                {
                    Message = "An error occurred while retrieving the model",
                    Error = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomResult<AccommodationModel>>> GetAccommodation(string id)
        {
            try
            {
                var resource = await _accommodationService.GetAccommodationById(id);
                if(resource != null)
                {
                    var response = new CustomResult<AccommodationModel>(200, "Get Employee successfully", resource, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<AccommodationModel>(404, "Resource not Found", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<AccommodationModel>()
                {
                    Message = "An error occurred while retrieving the model",
                    Error = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomResult<AccommodationModel>>> AddAccommodation( AccommodationModel accommodation)
        {
            try
            {
                var resource = await _accommodationService.AddAccommodation(accommodation);
                if(resource != null)
                {
                    var response = new CustomResult<AccommodationModel>(200, "Resource Created", accommodation, null);
                    return CreatedAtAction(nameof(GetAccommodation), new { id = accommodation.Accommodation_id }, accommodation);
                }
                else
                {
                    var response = new CustomResult<AccommodationModel>(400, "unable to create resource", null, null);
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<AccommodationModel>()
                {
                    Message = "An error occurred while retrieving the model",
                    Error = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomResult<AccommodationModel>>> UpdateAccommodation(AccommodationModel accommodation)
        {
            try
            {
                var resource = await _accommodationService.GetAccommodationById(accommodation.Accommodation_id);
                if(resource != null)
                {
                    var resourceUpdate = await _accommodationService.UpdateAccommodation(accommodation);
                    var response = new CustomResult<AccommodationModel>(200, "Update Accommodation Successfully", resourceUpdate, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<AccommodationModel>(400, "Cannot Update Accommodation", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<AccommodationModel>()
                {
                    Message = "An error occurred while retrieving the model",
                    Error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomResult<string>>> DeleteAccommodation(string id)
        {
            bool resourceDeleted = false;
            var resource = await _accommodationService.GetAccommodationById(id);

            if(resource != null)
            {
                resourceDeleted = await _accommodationService.DeleteAccommodation(id);
            }
            if (resourceDeleted)
            {
                var response = new CustomResult<string>(200, "Resource deleted successfully", null, null);
                return Ok(response);
            }
            else
            {
                var response = new CustomResult<string>(400, "Resource not found or unable to delete", null, null);
                return NotFound(response);
            }
        }
    }
}
