using KarnelTravelAPI.CustomResult;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("Admins")]
        [Authorize(Roles = $"{RoleModels.Admin}")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsersAsync()
        {
            try
            {
                var resources = await _userRepository.GetUsersAsync();
                if (resources != null && resources.Any())
                {
                    var response = new CustomStatusCode<IEnumerable<UserModel>>
                        (StatusCodes.Status200OK, "Get list successfully", resources, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomStatusCode<IEnumerable<UserModel>>
                        (StatusCodes.Status404NotFound, "Not found result", null, null);
                    return NotFound(resources);
                        
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                   
            }
        }
    }
}
