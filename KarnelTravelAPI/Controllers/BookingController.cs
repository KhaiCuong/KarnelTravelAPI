using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IBookingRepository _repository;


        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomResult<IEnumerable<BookingModel>>>> GetBookings()
        {
            try
            {
                var resources = await _repository.GetBookings();
                if (resources != null && resources.Any())
                {
                    var response = new CustomResult<IEnumerable<BookingModel>>(200, "Resources found", resources, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<BookingModel>>(404, "Not Resources Found", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<BookingModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }

        [HttpGet("{booking_id}")]
        public async Task<ActionResult<CustomResult<BookingModel>>> GetBookingByBookingId(int booking_id)
        {
            try
            {
                var resource = await _repository.GetBookingByBookingId(booking_id);
                if (resource == null)
                {
                    var response = new CustomResult<BookingModel>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<BookingModel>(200,
                        "Get employee successfully", resource, null);

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<BookingModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }

        }


            [HttpGet("{id}")]
        public async Task<ActionResult<CustomResult<IEnumerable<BookingModel>>>> GetBookingByUserId(int id)
        {
            try
            {
                var resource = await _repository.GetBookingById(id);
                if (resource == null)
                {
                    var response = new CustomResult<IEnumerable<BookingModel>>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<BookingModel>>(200,
                        "Get employee successfully", resource, null);

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<BookingModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }

        }




        [HttpPost]
        public async Task<ActionResult<CustomResult<BookingModel>>> AddBooking
          (BookingModel Booking)
        {
            try
            {
                var resource = await _repository.AddBooking(Booking);
                if (resource != null)
                {
                    var response = new CustomResult<BookingModel>(201, "Resource created",
                        Booking, null);
                    return Ok();

                }
                else
                {
                    var response = new CustomResult<BookingModel>(400,
                        "Unable to create resource", null, null);
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<BookingModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomResult<BookingModel>>> UpdateBooking
         (BookingModel Booking)
        {
            try
            {
                var resource = await _repository.UpdateBooking(Booking);
                if (resource != null)
                {
                    var response = new CustomResult<BookingModel>(200,
                        "update employee successfully", Booking, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<BookingModel>(404,
                        "No employee to update", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<BookingModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomResult<string>>> DeleteEmployee(int id)
        {
            bool resourceDeleted = false;
            var resource = await _repository.GetBookingById(id);

            if (resource != null)
            {
                resourceDeleted = await _repository.DeleteBooking(id);
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

