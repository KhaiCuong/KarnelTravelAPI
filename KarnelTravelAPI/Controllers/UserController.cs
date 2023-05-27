
using KarnelTravelAPI.CustomStatusCode;
using KarnelTravelAPI.Model;
using KarnelTravelAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        //[Route("Admins")]
        [Authorize(Roles = $"{RoleModels.Admin}")]
        public async Task<ActionResult<CustomResult<IEnumerable<UserModel>>>> GetUsersAsync()
        {
            try
            {
                var resources = await _userRepository.GetUsersAsync();
                if (resources != null && resources.Any())
                {
                    var response = new CustomResult<IEnumerable<UserModel>>
                        (StatusCodes.Status200OK, "Get list successfully", resources, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<IEnumerable<UserModel>>
                        (StatusCodes.Status404NotFound, "Not found result", null, null);
                    return NotFound(resources);
                        
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                new CustomResult<UserModel>()
                {
                    Message = "An error occured while retrived model",
                    Error = ex.Message
                });
                   
            }
        }


        [HttpGet("{id}")]
        //[Authorize(Roles = $"{RoleModels.Admin}")]
        public async Task<ActionResult<CustomResult<UserModel>>> GetUser(int id)
        {
            try
            {
                var resource = await _userRepository.GetUserByIdAsync(id);
                if (resource == null)
                {
                    var response = new CustomResult<UserModel>(404,
                        "Resource not found or unable to delete", null, null);
                    return NotFound(response);
                }
                else
                {
                    var response = new CustomResult<UserModel>(200,
                        "Get employee successfully", resource, null);

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<UserModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }

            

        }

        [HttpPost]
        //[Authorize(Roles = $"{RoleModels.Admin}")]
        public async Task<ActionResult<UserModel>> addUser(UserModel userModel)
        {
            try
            {
                var resource = await _userRepository.AddUserAsync(userModel);
                
                if (resource != null)
                {
                    var response = new CustomResult<UserModel>(201, "Resource created",
                       userModel, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<UserModel>(400,
                      "Unable to create resource", null, null);
                    return BadRequest(response);

                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new CustomResult<UserModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<CustomResult<UserModel>>> UpdateUserAsync(UserModel User)

        {
            try
            {
                var resource = await _userRepository.UpdateUserAsync(User);
                if (resource != null)
                {
                    var response = new CustomResult<UserModel>(200,
                        "update employee successfully", User, null);
                    return Ok(response);
                }
                else
                {
                    var response = new CustomResult<UserModel>(404,
                        "No employee to update", null, null);
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult<UserModel>()
                {
                    Message = "An error occurred while retrieving the model.",
                    Error = ex.Message
                });
            }

        }


        [HttpDelete("{id}")]
        //[Authorize(Roles = $"{RoleModels.Admin}")]
        public async Task<ActionResult<CustomResult<string>>> DeleteUserAsync(int id)
        {
            bool resourceDeleted = false;
            var resource = await _userRepository.GetUserByIdAsync(id);

            if (resource != null)
            {
                resourceDeleted = await _userRepository.DeleteUserAsync(id);
            }
            if (resourceDeleted)
            {

                var response = new CustomResult<string>(200,
                    "Resource deleted successfully", null, null);
                return Ok(response);
            }
            else
            {
                var response = new CustomResult<string>(404,
                    "Resource not found or unable to delete", null, null);
                return NotFound(response);
            }

        }
    }
}
