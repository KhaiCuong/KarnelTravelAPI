using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        public LocationController(ILocationRepository locationRepository)
        {
            this._locationRepository = locationRepository;
        }

        //get Locations
        [HttpGet]
        public async Task<ActionResult<CustomResult<IEnumerable<LocationModel>>>> GetLocations()
        {
            
            try
            {
                var resources = await _locationRepository.GetLocations();
                if (resources != null && resources.Any())
                {
                    var response = new CustomResult<IEnumerable<LocationModel>>(200,
                        "Resources found", resources, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<LocationModel>>(404,
                        "No resources found", null, null);
                    return (response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<LocationModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }

        }

        // Get location by id
        [HttpGet("{Location_id}")]
        public async Task<ActionResult<CustomResult<LocationModel>>> GetLocation(string Location_id)
        {
             
            try
            {
                var resource = await _locationRepository.GetLocationById(Location_id);
                if (resource == null)
                {
                    var response = new CustomResult<LocationModel>(404,
                        "Resource not found ", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<LocationModel>(200,
                        "Get Location successfully", resource, null);

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<LocationModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }

        // Add Location
        [HttpPost]
        public async Task<ActionResult<CustomResult<LocationModel>>> AddLocation(LocationModel location)
        {
            
            try
            {
                var resource = await _locationRepository.AddLocation(location);
                if (resource != null)
                {
                    var response = new CustomResult<LocationModel>(201, "Resource created",
                        location, null);
                    //return CreatedAtAction(nameof(GetLocation), new { id = location.Location_id },
                    //  location);
                    return response;

                }
                else
                {
                    var response = new CustomResult<LocationModel>(400,
                        "Unable to create resource", null, null);
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<LocationModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }

        //Upload Location
        [HttpPut("{Location_id}")]
        public async Task<ActionResult<CustomResult<LocationModel>>> UpdateLocation(
            LocationModel location)
        {
            try
            {
                var resource = await _locationRepository.GetLocationById(location.Location_id);
                if (resource != null)
                {
                    var resourceUpdate = await _locationRepository.UpdateLocation(
                        location);
                    var response = new CustomResult<LocationModel>(200,
                        "update employee successfully", resourceUpdate, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<LocationModel>(404,
                        "No employee to update", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<LocationModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }

        }

        [HttpDelete("{Location_id}")]
        public async Task<ActionResult<CustomResult<string>>> DeleteEmployee(string Location_id)
        {
            bool resourceDeleted = false;
            var resource = await _locationRepository.GetLocationById(Location_id);

            if (resource != null)
            {
                resourceDeleted = await _locationRepository.DeleteLocation(Location_id);
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


    }
}
