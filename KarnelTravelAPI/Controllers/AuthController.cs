using KarnelTravelAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration configuration;
        public AuthController(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            this.configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]

        public ActionResult Login(UserModel user)
        {
            var user = Authenticate
        }
    }
}
