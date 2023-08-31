using EShopperAPI.Application.Abstractions.Token;
using EShopperAPI.Domain.Entities.Identities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EShopperAPI.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(int lifetimeSeconds, AppUser user)
        {
            Application.DTOs.Token token = new Application.DTOs.Token();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["TokenSecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.ExpirationDate = DateTime.UtcNow.AddSeconds(lifetimeSeconds);

            JwtSecurityToken securityToken = new(
                audience: _configuration["TokenAudience"],
                issuer: _configuration["TokenIssuer"],
                expires: token.ExpirationDate,
                signingCredentials: signingCredentials,
                claims: new List<Claim> { new(ClaimTypes.Name, user.UserName) });

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            token.RefreshToken = CreateRefreshToken();
            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
