using EShopperAPI.Application.Abstractions.Services.Authentication;

namespace EShopperAPI.Application.Abstractions.Services
{
    public interface IAuthService : IInternalAuthentication, IExternalAuthentication
    {
    }
}
