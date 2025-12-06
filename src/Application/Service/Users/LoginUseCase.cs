
using Application.Dto.Query.Users;
using Application.Dto.Response.Users;
using Application.Port.In.Users;
using Application.Port.Out.Jwt;
using Application.Port.Out.UnitOfWork;
using Application.Port.Out.Users;

namespace Application.Service.Users
{
    public class LoginUseCase : ILoginUseCase
    {
        public IUserRepositoryPort _userRepositoryPort;
        public ITokenIssue _tokenIssue;
        public IUnitOfWork _unitOfWork;

        public LoginUseCase(IUserRepositoryPort userRepositoryPort, ITokenIssue tokenIssue, IUnitOfWork unitOfWork)
        {
            _userRepositoryPort = userRepositoryPort;
            _tokenIssue = tokenIssue;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<LoginResponse>> Login(LoginQuery query)
        {
            var encryptedPassword = _tokenIssue.EncryptSHA256(password);
            var user = await _userRepositoryPort.Login(userName, encryptedPassword);
            if (user is null)
            {
                return Error.NotFound("Usuario.NoEncontrado", "No se encontró un usuario con las credenciales proporcionadas.");
            }

            var response = new LoginResponse
            {
                Token = _tokenIssue.GenerateJWT(user, 1),
                RefreshToken = _tokenIssue.GenerateJWT(user, 2)
            };

            return response;
        }

    }
}
