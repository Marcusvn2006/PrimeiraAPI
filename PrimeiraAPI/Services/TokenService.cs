using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PrimeiraAPI.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrimeiraAPI.Services
{
    public class TokenService
    {
        public static object GenerateToken(IdentityUser user)
        {
            var key = Encoding.ASCII.GetBytes(MyKey.Secret);

            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
          new Claim("userId", user.Id.ToString() ),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new
            {
                token = tokenString
            };
        }

    }
}
