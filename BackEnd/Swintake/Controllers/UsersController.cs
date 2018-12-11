using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecuredWebApi.Services;
using Swintake.api.Helpers.Users;
using Swintake.domain.Users;
using Swintake.services.Users;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace Swintake.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IUserAuthenticationService _userAuthService;

        public UsersController(IUserAuthenticationService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public ActionResult<JwtSecurityToken> Authenticate([FromBody] UserDTO userDTO)
        {
            var securityToken = _userAuthService.Authenticate(userDTO.Email, userDTO.Password);

            if (securityToken != null)
            {
                var userName = _userAuthService.GetNameByMail(userDTO.Email);
                return Ok(securityToken);
            }

            return BadRequest("Email or Password incorrect!");
        }

        [HttpGet("{email}")]
        public string GetNameByMail([FromRoute] string email)
        {
            return _userAuthService.GetNameByMail(email);
        }
    }


}