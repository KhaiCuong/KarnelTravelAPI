using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomResult<IEnumerable<PaymentModel>>>> GetTours()
        {
            try
            {
                var resources = await _paymentRepository.GetPayments();
                if (resources != null && resources.Any())
                {
                    var response = new CustomResult<IEnumerable<PaymentModel>>(200, "Resources Found", resources, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<PaymentModel>>(404, "No resource Found", null, null);
                    return (response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<PaymentModel>()
                {
                    Message = "An error occurred while retrieving the model",
                    Error = ex.Message
                });
            }
        }

        [HttpPut("{booking_id}")]
        public async Task<ActionResult<CustomResult<IEnumerable<PaymentModel>>>> UpdateStatus(int booking_id)
        {
            try
            {
                var resource = await _paymentRepository.GetPaymentById(booking_id);
                if (resource != null)
                {
                    var resourceUpdate = await _paymentRepository.UpdatePayment(booking_id);
                    var response = new CustomResult<PaymentModel>(200, "Update tour Successfully", resourceUpdate, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<PaymentModel>(400, "Cannot Update tour", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<PaymentModel>()
                {
                    Message = "An error occurred while retrieving the model",
                    Error = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomResult<PaymentModel>>> GetTour(int id)
        {
            try
            {
                var resource = await _paymentRepository.GetPaymentById(id);
                if (resource != null)
                {
                    var response = new CustomResult<PaymentModel>(200, "Get Employee successfully", resource, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<PaymentModel>(404, "Resource not Found", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<PaymentModel>()
                {
                    Message = "An error occurred while retrieving the model",
                    Error = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomResult<PaymentModel>>> AddTour(PaymentModel payment)
        {
            try
            {
                var resource = await _paymentRepository.AddPayment(payment);
                if (resource != null)
                {
                    var response = new CustomResult<PaymentModel>(200, "Resource Created", payment, null);
                    return CreatedAtAction(nameof(GetTour), new { id = payment.Payment_id }, payment);
                }
                else
                {
                    var response = new CustomResult<PaymentModel>(400, "unable to create resource", null, null);
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<PaymentModel>()
                {
                    Message = "An error occurred while retrieving the model",
                    Error = ex.Message
                });
            }
        }

     
    }
}
