
using Application.Dto.Query.Users;
using Application.Dto.Response.Users;
using Application.Port.In.Users;
using Application.Port.Out.Jwt;
using Application.Port.Out.UnitOfWork;
using Application.Port.Out.Users;

namespace Application.Service.Users
{
    public class LoginService : ILoginUseCase
    {
        public IUserRepositoryPort _userRepositoryPort;
        public ITokenIssue _tokenIssue;

        public LoginService(IUserRepositoryPort userRepositoryPort, ITokenIssue tokenIssue)
        {
            _userRepositoryPort = userRepositoryPort;
            _tokenIssue = tokenIssue;
        }

        public async Task<ErrorOr<LoginResponse>> Login(LoginQuery query)
        {
            var encryptedPassword = _tokenIssue.EncryptSHA256(query.Password);
            var user = await _userRepositoryPort.Login(query.Username, encryptedPassword);
            if (user is null)
            {
                return Error.NotFound("Usuario.NoEncontrado", "No se encontró un usuario con las credenciales proporcionadas.");
            }

            var response = new LoginResponse(
                _tokenIssue.GenerateJWT(user, 1),
                _tokenIssue.GenerateJWT(user, 2)
            );

            return response;
        }

    }
}
