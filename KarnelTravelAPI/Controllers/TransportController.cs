using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportRepository _transportRepository;

        public TransportController(ITransportRepository transportRepository)
        {
            _transportRepository = transportRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomResult<IEnumerable<TransportModel>>>> GetTransports()
        {
            try
            {
                var resources = await _transportRepository.GetTransports();
                if (resources != null && resources.Any())
                {
                    var response = new CustomResult<IEnumerable<TransportModel>>
                         (200, "Resources found", resources, null);
                    return Ok(response);
                }
                else
                {
                    var reresponse = new CustomResult<IEnumerable<TransportModel>>
                        (404, "Not Resources Found", null, null);
                    return NotFound(reresponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<TransportModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message

                });
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CustomResult<TransportModel>>> GetTransportById(string id)
        {
            try
            {
                var resource = await _transportRepository.GetTransportById(id);
                if (resource == null)
                {
                    var response = new CustomResult<TransportModel> 
                        (404, "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult <TransportModel>
                        (200, "Get Source successfully", resource, null);
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<TransportModel>()
                {

                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomResult<TransportModel>>> AddTransport(TransportModel Transport)
        {
            try
            {
                var resource = await _transportRepository.AddTransport(Transport);
                if (resource != null)
                {
                    var response = new CustomResult<TransportModel>
                         (201, "Resource created",
                            Transport, null);
                    return CreatedAtAction(nameof(GetTransportById), new { id = Transport.Transport_id }, Transport);
                }
                else
                {
                    var response = new CustomResult<TransportModel>
                        (400, "Unable to create resource", null, null);
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<TransportModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomResult<TransportModel>>> UpdateTransport(TransportModel Transport)
        {
            try
            {
                var resource = await _transportRepository.UpdateTransport(Transport);
                if (resource != null)
                {
                    var response = new CustomResult<TransportModel>(200,
                        "update employee successfully", Transport, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<TransportModel>(404,
                       "No employee to update", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<TransportModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomResult<string>>> DeleteTransport(string id)
        {
            bool resourceDeleted = false;
            var resource = await _transportRepository.GetTransportById(id);
            if (resource != null)
            {
                resourceDeleted = await _transportRepository.DeleteTransport(id);

            }
            if (resourceDeleted)
            {
                var response = new CustomResult<string>
                    (200,
                    "Resource deleted successfully", null, null);
                return Ok(response);
            }
            else
            {
                var response = new CustomResult<string>
                    (200,
                    "Resource not found or unable to delete", null, null);
                return NotFound(response);
            }
        }

    }
}
