
using Application.Dto.Query.Users;
using Application.Dto.Response.Users;
using Application.Port.In.Users;
using Application.Port.Out.Jwt;
using Application.Port.Out.Users;

namespace Application.Service.Users
{
    public class RefreshTokenUseCase : IRefreshTokenUseCase
    {
        public IUserRepositoryPort _userRepositoryPort;
        public ITokenIssue _tokenIssue;

        public RefreshTokenUseCase(IUserRepositoryPort userRepositoryPort, ITokenIssue tokenIssue)
        {
            _userRepositoryPort = userRepositoryPort;
            _tokenIssue = tokenIssue;
        }

        public async Task<ErrorOr<LoginResponse>> RefreshToken(RefreshTokenQuery query)
        {
            if (_tokenIssue.DecodeJWT() is not UserResponse UserData)
            {
                return Error.NotFound("Autenticacion.TokenNoEcontrado", "No se ha encontrado el token del usuario.");
            }

            if (await _userRepositoryPort.FindById(new UserId(UserData.Id)) is not User user)
            {
                return Error.NotFound("Usuario.NoEncontrado", "No se encontro el usuario.");
            }

            var response = new LoginResponse(
                _tokenIssue.GenerateJWT(user, 1),
                _tokenIssue.GenerateJWT(user, 2)
            );

            return response;
        }
    }
}
