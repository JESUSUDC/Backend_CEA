using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Port.Out.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Security.Jwt
{
    public class TokenIssue : ITokenIssue
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenIssue(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string EncryptSHA256(string texto)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computar el Hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

                // Convertir el array de bytes a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public string GenerateJWT(User user, int opcion)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
            var credentias = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            // Crear la informacion del usuario para token
            var UserClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.Value.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.GivenName, user.LastName),
                new Claim(ClaimTypes.Upn, user.UserName)
            };

            // Crear detalle del token
            var jwtConfig = new JwtSecurityToken(
                _configuration["Jwt:issuer"],
                _configuration["Jwt:Audience"],
                claims: UserClaims,
                expires: opcion switch
                {
                    1 => DateTime.Now.AddMinutes(60),
                    2 => DateTime.Now.AddMinutes(80),
                    _ => throw new ArgumentOutOfRangeException(nameof(opcion), "Opción no válida.")
                },
                signingCredentials: credentias
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }

        public UserResponse? DecodeJWT()
        {
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;

            if (identity == null)
            {
                return null;
            }

            var userClaims = identity.Claims;

            var idClaim = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            var nameClaim = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Name)?.Value;
            var lastNameClaim = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName)?.Value;
            var userNameClaim = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Upn)?.Value;


            if (
                Guid.TryParse(idClaim, out var id) &&
                !string.IsNullOrEmpty(nameClaim) &&
                !string.IsNullOrEmpty(lastNameClaim) &&
                !string.IsNullOrEmpty(userNameClaim)
            )
            {
                return new UserResponse(
                    id,
                    nameClaim,
                    lastNameClaim,
                    userNameClaim
                );
            }

            return null;
        }
    }
}
