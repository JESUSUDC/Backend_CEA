
using Application.Dto.Query.Users;
using Application.Dto.Response.Users;

namespace Application.Port.In.Users
{
    public interface ILoginUseCase
    {
        public Task<ErrorOr<LoginResponse>> Login(LoginQuery query);
    }
}
