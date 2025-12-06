
using Application.Dto.Query.Users;
using Application.Dto.Response.Users;

namespace Application.Port.In.Users
{
    public interface IRefreshTokenUseCase
    {
        public Task<ErrorOr<LoginResponse>> RefreshToken(RefreshTokenQuery query);
    }
}
