using BlazorSozluk.Api.Application.Features.Commands.User.ConfirmEmail;
using BlazorSozluk.Common.Events.User;
using BlazorSozluk.Common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorSozluk.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        [Route("Confirm")]
        public async Task<IActionResult> ConfirmEmail(Guid id)
        {

            var res = await mediator.Send(new ConfirmEmailCommand { ConfirmationId = id });
            return Ok(res);
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            if (!command.UserId.HasValue)
                command.UserId = UserId;
            var res = await mediator.Send(command);
            return Ok(res);
        }
    }
}
