using Application.Dto.Response.Users;
using Domain.Users.Entity;

namespace Application.Port.Out.Jwt
{
    public interface ITokenIssue
    {
        string EncryptSHA256(string texto);
        string GenerateJWT(User usuario, int opcion);
        UserResponse? DecodeJWT();
    }
}
