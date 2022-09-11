using Application.Features.UserSocialMedias.Commands.CreateUserSocialMedia;
using Application.Features.UserSocialMedias.Commands.DeleteUserSocialMedia;
using Application.Features.UserSocialMedias.Commands.UpdateUserSocialMedia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSocialMediasController : BaseController
    {
        [HttpPost, Authorize]
        public async Task<IActionResult> Create([FromBody] CreateUserSocialMediaCommand createUserSocialMediaCommand)
        {
            var result = await Mediator.Send(createUserSocialMediaCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserSocialMediaCommand createUserSocialMediaCommand)
        {
            var result = await Mediator.Send(createUserSocialMediaCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserSocialMediaCommand deleteUserSocialMediaCommand)
        {
            var result = await Mediator.Send(deleteUserSocialMediaCommand);
            return Ok(result);
        }
    }
}
