using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model.MultiServiceModel;
using KarnelTravelAPI.Repository.MultiServiceRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers.MultiServiceController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TouristSpotTourController : ControllerBase
    {
        private readonly ITouristSpotTourRepository _repository;
        public TouristSpotTourController(ITouristSpotTourRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("{TouristSpot_id}")]
        public async Task<ActionResult<CustomResult<IEnumerable<TouristSpotTourModel>>>> GetListByTouristSpotId(string TouristSpot_id)
        {
            try
            {
                var resource = await _repository.GetTouristSpotTourById(TouristSpot_id);
                if (resource == null)
                {
                    var response = new CustomResult<IEnumerable<TouristSpotTourModel>>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<TouristSpotTourModel>>(200,
                        "Get All TouristSpotTour successfully", resource, null);

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
        public async Task<ActionResult<CustomResult<IEnumerable<TouristSpotTourModel>>>> GetListByTourId(string Tour_id)
        {
            try
            {
                var resource = await _repository.GetByTourId(Tour_id);
                if (resource == null)
                {
                    var response = new CustomResult<IEnumerable<TouristSpotTourModel>>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<TouristSpotTourModel>>(200,
                        "Get All TouristSpotTour successfully", resource, null);

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
        public async Task<ActionResult<CustomResult<bool>>> PostTouristSpotTour(List<string> TouristSpot_ids, string Tour_Id)
        {
            try
            {
                var resources = await _repository.AddTouristSpotTour(TouristSpot_ids, Tour_Id);
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
            var resource = await _repository.DeleteTouristSpotTour(Tour_id);
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
