using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _repository;


        public FeedbackController(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomResult<IEnumerable<FeedbackModel>>>> GetFeedbacks()
        {
            try
            {
                var resources = await _repository.GetFeedbacks();
                if (resources != null && resources.Any())
                {
                    var response = new CustomResult<IEnumerable<FeedbackModel>>(200, "Resources found", resources, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<FeedbackModel>>(404, "Not Resources Found", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<FeedbackModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }

        [HttpGet("{Feedback_id}")]
        public async Task<ActionResult<CustomResult<FeedbackModel>>> GetFeedbackById(int Feedback_id)
        {
            try
            {
                var resource = await _repository.GetFeedbacksById(Feedback_id);
                if (resource == null)
                {
                    var response = new CustomResult<FeedbackModel>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<FeedbackModel>(200,
                        "Get employee successfully", resource, null);

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<FeedbackModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }

        }

        [HttpPost]
        public async Task<ActionResult<CustomResult<FeedbackModel>>> AddFeedback
         (FeedbackModel feedback)
        {
            try
            {
                var resource = await _repository.AddFeedback(feedback);
                if (resource != null)
                {
                    var response = new CustomResult<FeedbackModel>(201, "Resource created",
                        feedback, null);
                    return CreatedAtAction(nameof(GetFeedbackById), new { Feedback_id = feedback.Feedback_id },
                        feedback);

                }
                else
                {
                    var response = new CustomResult<FeedbackModel>(400,
                        "Unable to create resource", null, null);
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<FeedbackModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }

        }

        [HttpPut("{Feedback_id}")]
        public async Task<ActionResult<CustomResult<FeedbackModel>>> UpdateBooking
        (FeedbackModel feedback)
        {
            try
            {
                var resource = await _repository.UpdateFeedback(feedback);
                if (resource != null)
                {
                    var response = new CustomResult<FeedbackModel>(200,
                        "update Feedback successfully", feedback, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<FeedbackModel>(404,
                        "No Feedback to update", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<FeedbackModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }

        }


        [HttpDelete("{Feedback_id}")]
        public async Task<ActionResult<CustomResult<string>>> DeleteEmployee(int Feedback_id)
        {
            bool resourceDeleted = false;
            var resource = await _repository.GetFeedbacksById(Feedback_id);

            if (resource != null)
            {
                resourceDeleted = await _repository.DeleteFeedback(Feedback_id);
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
