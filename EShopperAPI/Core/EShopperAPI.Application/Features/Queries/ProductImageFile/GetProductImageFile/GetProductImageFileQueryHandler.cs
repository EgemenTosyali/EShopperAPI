using EShopperAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EShopperAPI.Application.Features.Queries.ProductImageFile.GetProductImageFile
{
    public class GetProductImageFileQueryHandler : IRequestHandler<GetProductImageFileQueryRequest, List<GetProductImageFileQueryResponse>>
    {
        private IProductReadRepository _productReadRepository;
        private IConfiguration _configuration;

        public GetProductImageFileQueryHandler(IConfiguration configuration, IProductReadRepository productReadRepository)
        {
            _configuration = configuration;
            _productReadRepository = productReadRepository;
        }

        public async Task<List<GetProductImageFileQueryResponse>> Handle(GetProductImageFileQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            return product?.ProductImageFiles.Select(p => new GetProductImageFileQueryResponse
            {
                Path = $"{_configuration["GoogleCloudUrl"]}/{p.FilePath}",
                FileName = p.FileName,
                Id = p.Id
            }).ToList();
        }
    }
}
