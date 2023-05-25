using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Model.ImageModel;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers.ImageController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationImageController : ControllerBase
    {
        private readonly IAccommodationImageRepository _accommodation;
        public AccommodationImageController(IAccommodationImageRepository IAccommodation)
        {
            _accommodation = IAccommodation;
        }

        [HttpGet]
        public async Task<ActionResult<CustomResult<IEnumerable<AccommodationImageModel>>>> GetAllAccommodationImages()
        {
            try
            {
                var resource = await _accommodation.GetAllAccommodationImages();
                if (resource == null)
                {
                    var response = new CustomResult<IEnumerable<AccommodationImageModel>>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<AccommodationImageModel>>(200,
                        "Get All Accommodation Image successfully", resource, null);

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

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomResult<IEnumerable<string>>>> GetImagesByTouristSpotId(string id)
        {
            try
            {
                var resource = await _accommodation.GetAccommodationImage(id);
                if (resource == null)
                {
                    var response = new CustomResult<IEnumerable<string>>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<string>>(200,
                        "Get Accommodation Image successfully", resource, null);

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


        [HttpPut("{id}")] // id = TouristSpot_Id
        public async Task<ActionResult<CustomResult<bool>>> UpdateImageById(List<IFormFile> files, string id)
        {
            try
            {
                var resources = await _accommodation.UpdateAccommodationImage(files, id);
                if (resources)
                {
                    var response = new CustomResult<IEnumerable<AccommodationModel>>(200, "Resource created", null, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<AccommodationModel>>(404, "No Resources Found", null, null);
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
        public async Task<ActionResult<CustomResult<bool>>> PostImages(List<IFormFile> files, string Accommodation_Id)
        {
            try
            {
                var resources = await _accommodation.AddAccommodationImages(files, Accommodation_Id);
                if (resources)
                {
                    var response = new CustomResult<IEnumerable<AccommodationModel>>(200, "Resource created", null, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<AccommodationModel>>(404, "Not Resources Found", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<AccommodationModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomResult<string>>> DeleteImages(string id)
        {
            bool resourceDeleted = false;
            var resource = await _accommodation.DeleteAccommodationImage(id);
            if (resource != null)
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
