
using Application.Dto.Response.Users;

namespace Application.Port.In.Users
{
    public interface IUserDataUseCase
    {
        public Task<ErrorOr<UserResponse>> UserData();
    }
}
