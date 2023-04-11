﻿using FitPlannerAPI.Models.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace FitPlannerAPI.Repositories.Repositories.UserRepositoriy
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public TokenHandler(IConfiguration configuration, IUserRepository userRepository)
        {
            this._configuration = configuration;
            this._userRepository = userRepository;
        }

        public async Task<string> GetToken(User user)
        {
            // Create Claims
            var claims = new List<Claim>();
            var role = await _userRepository.GetUserRoleById(user.Id);

            claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Role, role.Name));

            // Create credentials
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create token
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            var result = await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

            return result;
        }
    }
}
