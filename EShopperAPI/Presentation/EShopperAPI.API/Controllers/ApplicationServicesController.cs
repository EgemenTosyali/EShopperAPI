using EShopperAPI.Application.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopperAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationServicesController : ControllerBase
    {
        IApplicationService _applicationService;

        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult GetAuthorizationDefnitionEndpoints()
        {
            var result = _applicationService.GetAuthorizationDefinitionAttributes(typeof(Program));
            return Ok(result);
        }
    }
}
