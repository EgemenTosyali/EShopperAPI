using EShopperAPI.Application.Attributes;
using EShopperAPI.Application.Consts;
using EShopperAPI.Application.Enums;
using EShopperAPI.Application.Features.Commands.AppUser.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShopperAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AuthorizationDefinition(Menu = AuthorizationDefinitionConstants.Users, Definition = "Create User Command", ActionType = ActionType.Create)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);

        }
    }
}
