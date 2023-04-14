using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Features.Commands.ProductImageFile.UploadProductImageFile
{
    public class UploadProductImageFileCommandRequest : IRequest<UploadProductImageFileCommandResponse>
    {
        public string Id { get; set; }
        public IFormCollection FormFileCollection { get; set; }
    }
}
