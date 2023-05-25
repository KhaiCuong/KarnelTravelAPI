using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers.ImageController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristSpotImageController : ControllerBase
    {
        private readonly ITouristSpotImageRepository _repository;
        public TouristSpotImageController(ITouristSpotImageRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomResult<IEnumerable<string>>>> GetImagesByTouristSpotId(string id )
        {
            try
            {
                var resource = await _repository.GetListImgById(id);
                if (resource == null)
                {
                    var response = new CustomResult<IEnumerable<string>>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<string>>(200,
                        "Get employee successfully", resource, null);

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
                var resources = await _repository.UpdateImg(files, id);
                if (resources)
                {
                    var response = new CustomResult<IEnumerable<TouristSpotModel>>(200, "Resource created", null, null);
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


        [HttpPost]
        public async Task<ActionResult<CustomResult<bool>>> PostImages(List<IFormFile> files, string TouristSpot_Id)
        {
            try
            {
                var resources = await _repository.AddImage(files, TouristSpot_Id);
                if (resources)
                {
                    var response = new CustomResult<IEnumerable<TouristSpotModel>>(200, "Resource created",null, null);
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
        public async Task<ActionResult<CustomResult<string>>> DeleteImages(string id)
        {
            bool resourceDeleted = false;
            var resource = await _repository.DeleteImage(id);
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
