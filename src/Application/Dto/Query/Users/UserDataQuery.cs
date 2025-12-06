
using Application.Dto.Response.Users;

namespace Application.Dto.Query.Users
{
    public record UserDataQuery() : IRequest<ErrorOr<UserResponse>>;
}
