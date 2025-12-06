
using Application.Dto.Query.Users;
using Application.Dto.Response.Users;
using Application.Port.In.Users;
using Application.Port.Out.Jwt;

namespace Application.Service.Users
{
    public class UserDataUseCase : IUserDataUseCase
    {
        public ITokenIssue _tokenIssue;

        public UserDataUseCase(ITokenIssue tokenIssue)
        {
            _tokenIssue = tokenIssue;
        }

        public Task<ErrorOr<UserResponse>> Handle(UserDataQuery query)
        {
            if (_tokenIssue.DecodeJWT() is not UserResponse userData)
            {
                return Task.FromResult<ErrorOr<UserResponse>>(
                    Error.NotFound("Autenticacion.TokenNoEcontrado", "No se ha encontrado el token del usuario.")
                );
            }

            return Task.FromResult<ErrorOr<UserResponse>>(userData);
        }
    }
}
