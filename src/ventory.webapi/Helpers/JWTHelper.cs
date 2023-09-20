using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using ventory.application.models;

namespace ventory.webapi.Helpers
{
    public class JWTHelper
    {
     
        public static string CreateToken(UserResponseModel loginModel, IConfiguration configuration)
        {

            var tokenKey = GetTokenKey(configuration);
            var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Sid, loginModel.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, loginModel.Email),
                new Claim(JwtRegisteredClaimNames.NameId, loginModel.CompanyName)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token");
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string GetTokenKey(IConfiguration configuration) => configuration["TokenKey"] ?? "TokenKey";
        
    }
}