using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecuredWebApi.Services;
using Swintake.api.Helpers.Users;
using Swintake.domain.Users;

namespace Swintake.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly UserAuthenticationService _userAuthService;

        public UsersController(UserRepository userRepository, UserAuthenticationService userAuthService)
        {
            _userRepository = userRepository;
            _userAuthService = userAuthService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public ActionResult<string> Authenticate([FromBody] UserDTO userDTO)
        {
            var securityToken = _userAuthService.Authenticate(userDTO.Email, userDTO.Password);

            if (securityToken != null)
            {
                return Ok(securityToken.RawData);
            }

            return BadRequest("Email or Password incorrect!");
        }
    }


}