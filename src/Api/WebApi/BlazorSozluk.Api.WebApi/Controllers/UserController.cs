using BlazorSozluk.Api.Application.Features.Commands.User.ConfirmEmail;
using BlazorSozluk.Api.Application.Features.Queries.GetUserDetail;
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

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await mediator.Send(new GetUserDetailQuery(id));
            return Ok(res);
        }

        [HttpGet]
        [Route("UserName/{userName}")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            var res = await mediator.Send(new GetUserDetailQuery(Guid.Empty, userName));
            return Ok(res);
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
