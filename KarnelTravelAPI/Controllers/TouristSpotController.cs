using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristSpotController : ControllerBase
    {
        private readonly ITouristSpotRepository _repository;


        public TouristSpotController(ITouristSpotRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomResult<IEnumerable<TouristSpotModel>>>> GetTouristSpots()
        {
            try
            {
                var resources = await _repository.GetTouristSpots();
                if (resources != null && resources.Any())
                {
                    var response = new CustomResult<IEnumerable<TouristSpotModel>>(200, "Resources found", resources, null);
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



        [HttpGet("{id}")]
        public async Task<ActionResult<CustomResult<TouristSpotModel>>> GetTouristSpotById(string id)
        {
            try
            {
                var resource = await _repository.GetTouristSpotById(id);
                if (resource == null)
                {
                    var response = new CustomResult<TouristSpotModel>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<TouristSpotModel>(200,
                        "Get employee successfully", resource, null);

                    return Ok(response);
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
        public async Task<ActionResult<CustomResult<TouristSpotModel>>> AddTouristSpot
          ([FromForm] TouristSpotModel touristSpot)
        {
                  try
                {
                    var resource = await _repository.AddTouristSpot(touristSpot);
                    if (resource != null)
                    {
                        var response = new CustomResult<TouristSpotModel>(201, "Resource created",
                            touristSpot, null);
                        return CreatedAtAction(nameof(GetTouristSpotById), new { id = touristSpot.TouristSpot_id },
                            touristSpot);

                    }
                    else
                    {
                        var response = new CustomResult<TouristSpotModel>(400,
                            "Unable to create resource", null, null);
                        return BadRequest(response);
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
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomResult<TouristSpotModel>>> UpdateTouristSpot
         ([FromForm]  TouristSpotModel touristSpot)
        {
            try
            {
                var resource = await _repository.UpdateTouristSpot(touristSpot);
                if (resource != null)
                {
                    var response = new CustomResult<TouristSpotModel>(200,
                        "update employee successfully", touristSpot, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<TouristSpotModel>(404,
                        "No employee to update", null, null);
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
        public async Task<ActionResult<CustomResult<string>>> DeleteEmployee(string id)
        {
            bool resourceDeleted = false;
            var resource = await _repository.GetTouristSpotById(id);

            if (resource != null)
            {
                resourceDeleted = await _repository.DeleteTouristSpot(id);
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
