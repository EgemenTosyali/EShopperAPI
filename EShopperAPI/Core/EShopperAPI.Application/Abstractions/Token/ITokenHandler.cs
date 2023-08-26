using EShopperAPI.Domain.Entities.Identities;

namespace EShopperAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int accessTokenLifeTime, AppUser user);
        string CreateRefreshToken();
    }
}
