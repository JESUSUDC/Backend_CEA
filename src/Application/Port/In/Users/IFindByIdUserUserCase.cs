
using Application.Dto.Query.Users;
using Application.Dto.Response.Users;

namespace Application.Port.In.Users
{
    public interface IFindByIdUserUserCase
    {
        public Task<ErrorOr<UserResponse>> FindByIdUser(FindByIdUserQuery query);
    }
}
