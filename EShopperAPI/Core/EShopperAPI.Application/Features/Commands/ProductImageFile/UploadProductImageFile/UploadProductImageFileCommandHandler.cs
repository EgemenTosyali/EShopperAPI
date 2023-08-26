using EShopperAPI.Application.Abstractions.Storage;
using EShopperAPI.Application.Repositories;
using MediatR;

namespace EShopperAPI.Application.Features.Commands.ProductImageFile.UploadProductImageFile
{
    public class UploadProductImageFileCommandHandler : IRequestHandler<UploadProductImageFileCommandRequest, UploadProductImageFileCommandResponse>
    {
        private IStorageService _storageService;
        private IProductImageFileWriteRepository _productImageFileWriteRepository;
        private IProductReadRepository _productReadRepository;

        public UploadProductImageFileCommandHandler(IStorageService storageService, IProductImageFileWriteRepository productImageFileWriteRepository, IProductReadRepository productReadRepository)
        {
            _storageService = storageService;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<UploadProductImageFileCommandResponse> Handle(UploadProductImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            var datas = await _storageService.UploadAsync("files", request.FormFileCollection.Files);
            var product = await _productReadRepository.GetByIdAsync(request.Id);

            await _productImageFileWriteRepository.AddRangeAsync(datas.Select(d => new Domain.Entities.ProductImageFile()
            {
                FileName = d.fileName,
                FilePath = d.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<Domain.Entities.Product>() { product }
            }).ToList());

            await _productImageFileWriteRepository.SaveAsync();

            return new();
        }
    }
}
