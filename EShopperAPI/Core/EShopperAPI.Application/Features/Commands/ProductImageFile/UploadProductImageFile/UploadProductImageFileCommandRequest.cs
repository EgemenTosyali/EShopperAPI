using MediatR;
using Microsoft.AspNetCore.Http;

namespace EShopperAPI.Application.Features.Commands.ProductImageFile.UploadProductImageFile
{
    public class UploadProductImageFileCommandRequest : IRequest<UploadProductImageFileCommandResponse>
    {
        public string Id { get; set; }
        public IFormCollection FormFileCollection { get; set; }
    }
}
