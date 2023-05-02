using EShopperAPI.Application.Abstractions.Storage;
using EShopperAPI.Application.Features.Commands.Product.CreateProduct;
using EShopperAPI.Application.Features.Commands.Product.RemoveProduct;
using EShopperAPI.Application.Features.Commands.ProductImageFile.RemoveProductImageFile;
using EShopperAPI.Application.Features.Commands.ProductImageFile.UploadProductImageFile;
using EShopperAPI.Application.Features.Queries.Product.GetAllProduct;
using EShopperAPI.Application.Features.Queries.Product.GetByIdProduct;
using EShopperAPI.Application.Features.Queries.ProductImageFile.GetProductImageFile;
using EShopperAPI.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShopperAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ProductsController : ControllerBase
    {
        readonly private IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest request)
        {
            GetByIdProductQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest request)
        {
            GetAllProductQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest request)
        {
            RemoveProductCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageFileCommandRequest request)
        {
            UploadProductImageFileCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImageFileQueryRequest request)
        {
            List<GetProductImageFileQueryResponse> response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageFileCommandRequest request, string ImageId)
        {
            request.ImageId = ImageId;
            RemoveProductImageFileCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
