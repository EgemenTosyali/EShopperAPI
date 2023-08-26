using EShopperAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShopperAPI.Application.Features.Commands.ProductImageFile.RemoveProductImageFile
{
    public class RemoveProductImageFileCommandHandler : IRequestHandler<RemoveProductImageFileCommandRequest, RemoveProductImageFileCommandResponse>
    {
        private IProductReadRepository _productReadRepository;
        private IProductImageFileWriteRepository _productImageFileWriteRepository;

        public RemoveProductImageFileCommandHandler(IProductReadRepository productReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
        }

        public async Task<RemoveProductImageFileCommandResponse> Handle(RemoveProductImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
            .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            Domain.Entities.ProductImageFile productImageFile = product.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));
            product.ProductImageFiles.Remove(productImageFile);
            await _productImageFileWriteRepository.SaveAsync();

            return new();
        }
    }
}
