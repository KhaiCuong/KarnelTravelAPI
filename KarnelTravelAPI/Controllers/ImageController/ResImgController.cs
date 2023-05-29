using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository.ImageRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers.ImageController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResImgController : ControllerBase
    {
        private readonly IRestaurantImageRepository _repository;
        public ResImgController(IRestaurantImageRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomResult<IEnumerable<string>>>> GetImagesByRestaurantId(string id)
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


        [HttpPost("{id}")] // id = Restaurant_Id
        public async Task<ActionResult<CustomResult<bool>>> UpdateImageById(List<IFormFile> files, string id)
        {
            try
            {
                var resources = await _repository.UpdateImg(files, id);
                if (resources)
                {
                    var response = new CustomResult<bool>(200, "Resource created", resources, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<bool>(404, "Not Resources Found", resources, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<RestaurantModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }


        [HttpPost]
        public async Task<ActionResult<CustomResult<bool>>> PostImages(List<IFormFile> files, string Restaurant_id)
        {
            try
            {
                var resources = await _repository.AddImage(files, Restaurant_id);
                if (resources)
                {
                    var response = new CustomResult<bool>(200, "Resource created", resources, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<bool>(404, "Not Resources Found", resources, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<RestaurantModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomResult<bool>>> DeleteImages(string id)
        {
            var resource = await _repository.DeleteImage(id);
            if (resource != null)
            {

                var response = new CustomResult<bool>(200,
                    "Resource deleted successfully", true, null);
                return Ok(response);
            }
            else
            {
                var response = new CustomResult<bool>(200,
                    "Resource not found or unable to delete", false, null);
                return NotFound(response);
            }

        }
    }
}

