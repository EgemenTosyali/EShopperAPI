﻿using EShopperAPI.Application.Abstractions.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(int lifetimeMinute)
        {
            Application.DTOs.Token token = new Application.DTOs.Token();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.ExpirationDate = DateTime.UtcNow.AddMinutes(lifetimeMinute);

            JwtSecurityToken securityToken = new(
                audience: configuration["Token:Audience"],
                issuer: configuration["Token:Issuer"],
                expires: token.ExpirationDate,
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}