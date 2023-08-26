using MediatR;

namespace EShopperAPI.Application.Features.Queries.ProductImageFile.GetProductImageFile
{
    public class GetProductImageFileQueryRequest : IRequest<List<GetProductImageFileQueryResponse>>
    {
        public string Id { get; set; }
    }
}
