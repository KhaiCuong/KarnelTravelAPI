using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Model.MultiServiceModel;
using KarnelTravelAPI.Repository.ImageRepository;
using KarnelTravelAPI.Repository.MultiServiceRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers.MultiServiceController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccommodationTourController : ControllerBase
    {
        private readonly IAccommodationTourRepository _repository;
        public AccommodationTourController(IAccommodationTourRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("{Accommodation_id}")]
        public async Task<ActionResult<CustomResult<IEnumerable<AccommodationTourModel>>>> GetListByAccommodationId(string Accommodation_id)
        {
            try
            {
                var resource = await _repository.GetByAccommodationId(Accommodation_id);
                if (resource == null)
                {
                    var response = new CustomResult<IEnumerable<AccommodationTourModel>>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<AccommodationTourModel>>(200,
                        "Get All AccommodationTour successfully", resource, null);

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
        public async Task<ActionResult<CustomResult<IEnumerable<AccommodationTourModel>>>> GetListByTourId(string Tour_id)
        {
            try
            {
                var resource = await _repository.GetByTourId(Tour_id);
                if (resource == null)
                {
                    var response = new CustomResult<IEnumerable<AccommodationTourModel>>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<AccommodationTourModel>>(200,
                        "Get All AccommodationTour successfully", resource, null);

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
        public async Task<ActionResult<CustomResult<bool>>> PostAccommodationTour(List<string> Accommodation_ids, string Tour_Id)
        {
            try
            {
                var resources = await _repository.AddAccommodationTour(Accommodation_ids, Tour_Id);
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
            var resource = await _repository.DeleteAccommodationTour(Tour_id);
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
