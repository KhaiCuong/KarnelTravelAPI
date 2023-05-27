using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourRepository _tourRepository;

        public TourController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomResult<IEnumerable<TourModel>>>> GetTours()
        {
            try
            {
                var resources = await _tourRepository.GetTours();
                if (resources != null && resources.Any())
                {
                    var response = new CustomResult<IEnumerable<TourModel>>(200, "Resources Found", resources, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<TourModel>>(404, "No resource Found", null, null);
                    return (response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<TourModel>()
                {
                    Message = "An error occurred while retrieving the model",
                    Error = ex.Message
                });
            }
        }

        [HttpPut("{tour_id}")]
        public async Task<ActionResult<CustomResult<IEnumerable<TourModel>>>> UpdateStatus(int tour_id)
        {
            try
            {
                var resource = await _tourRepository.GetTourById(tour_id);
                if (resource != null)
                {
                    var resourceUpdate = await _tourRepository.UpdateStatus_tour(tour_id);
                    var response = new CustomResult<TourModel>(200, "Update tour Successfully", resourceUpdate, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<TourModel>(400, "Cannot Update tour", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<TourModel>()
                {
                    Message = "An error occurred while retrieving the model",
                    Error = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomResult<TourModel>>> GetTour(int id)
        {
            try
            {
                var resource = await _tourRepository.GetTourById(id);
                if (resource != null)
                {
                    var response = new CustomResult<TourModel>(200, "Get Employee successfully", resource, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<TourModel>(404, "Resource not Found", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<TourModel>()
                {
                    Message = "An error occurred while retrieving the model",
                    Error = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomResult<TourModel>>> AddTour(TourModel tour)
        {
            try
            {
                var resource = await _tourRepository.AddTour(tour);
                if (resource != null)
                {
                    var response = new CustomResult<TourModel>(200, "Resource Created", tour, null);
                    return CreatedAtAction(nameof(GetTour), new { id = tour.Tour_id }, tour);
                }
                else
                {
                    var response = new CustomResult<TourModel>(400, "unable to create resource", null, null);
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<TourModel>()
                {
                    Message = "An error occurred while retrieving the model",
                    Error = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomResult<TourModel>>> Updatetour(TourModel tour)
        {
            try
            {
                var resource = await _tourRepository.GetTourById(tour.Tour_id);
                if (resource != null)
                {
                    var resourceUpdate = await _tourRepository.UpdateTour(tour);
                    var response = new CustomResult<TourModel>(200, "Update tour Successfully", resourceUpdate, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<TourModel>(400, "Cannot Update tour", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<TourModel>()
                {
                    Message = "An error occurred while retrieving the model",
                    Error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomResult<string>>> Deletetour(int id)
        {
            bool resourceDeleted = false;
            var resource = await _tourRepository.GetTourById(id);

            if (resource != null)
            {
                resourceDeleted = await _tourRepository.DeleteTour(id);
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
