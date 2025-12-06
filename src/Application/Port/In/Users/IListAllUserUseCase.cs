
using Application.Dto.Query.Users;
using Application.Dto.Response.Users;

namespace Application.Port.In.Users
{
    public interface IListAllUserUseCase
    {
        public Task<ErrorOr<IReadOnlyList<UserResponse>>> ListAllUsers(ListAllUserQuery query);
    }
}
