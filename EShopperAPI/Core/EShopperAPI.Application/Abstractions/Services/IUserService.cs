using EShopperAPI.Application.DTOs.User;
using EShopperAPI.Domain.Entities.Identities;

namespace EShopperAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int refreshTokenLifeTime);
    }
}
