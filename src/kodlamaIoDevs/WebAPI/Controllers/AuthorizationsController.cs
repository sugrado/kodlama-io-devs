using Application.Features.Authorizations.Commands.LoginUser;
using Application.Features.Authorizations.Commands.RegisterUser;
using Core.Security.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationsController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            var registerUserCommand = new RegisterUserCommand { UserForRegisterDto = userForRegisterDto };
            await Mediator.Send(registerUserCommand);
            return Ok("Successfully registered!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var loginUserCommand = new LoginUserCommand { UserForLoginDto = userForLoginDto };
            var result = await Mediator.Send(loginUserCommand);
            return Ok(result);
        }
    }
}
