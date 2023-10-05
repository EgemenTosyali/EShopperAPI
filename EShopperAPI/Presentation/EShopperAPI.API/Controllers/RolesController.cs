using EShopperAPI.Application.Attributes;
using EShopperAPI.Application.Enums;
using EShopperAPI.Application.Features.Commands.Roles.CreateRole;
using EShopperAPI.Application.Features.Commands.Roles.DeleteRole;
using EShopperAPI.Application.Features.Commands.Roles.UpdateRole;
using EShopperAPI.Application.Features.Queries.Roles.GetAllRoles;
using EShopperAPI.Application.Features.Queries.Roles.GetRolesById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopperAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly IMediator mediator;

        public RolesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("[action]")]
        [AuthorizationDefinition(Menu ="Roles",ActionType =ActionType.Read,Definition = "Get All Roles Query")]
        public async Task<IActionResult> GetRoles([FromQuery] GetAllRolesQueryRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]/{Id}")]
        [AuthorizationDefinition(Menu = "Roles", ActionType = ActionType.Read, Definition = "Get By Id Roles Query")]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesByIdQueryRequest request)
        {
            var result = await mediator.Send(request);  
            return Ok(result);
        }
        [HttpPost("[action]")]
        [AuthorizationDefinition(Menu = "Roles", ActionType = ActionType.Create, Definition = "Create Role Command")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("[action]/{Id}")]
        [AuthorizationDefinition(Menu = "Roles", ActionType = ActionType.Update, Definition = "Update Role Command")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("[action]/{name}")]
        [AuthorizationDefinition(Menu = "Roles", ActionType = ActionType.Delete, Definition = "Delete Role Command")]
        public async Task<IActionResult> DeleteRole([FromBody] DeleteRoleCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
