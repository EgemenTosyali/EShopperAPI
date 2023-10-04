using EShopperAPI.Application.Attributes;
using EShopperAPI.Application.Configurations;
using EShopperAPI.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopperAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ApplicationServicesController : ControllerBase
    {
        IApplicationService _applicationService;

        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [AuthorizationDefinition(ActionType = ActionType.Read,Definition = "Get Authorization Definition Attributes",Menu = "ApplicationServices")]
        public IActionResult GetAuthorizationDefnitionEndpoints()
        {
            var result = _applicationService.GetAuthorizationDefinitionAttributes(typeof(Program));
            return Ok(result);
        }
    }
}
