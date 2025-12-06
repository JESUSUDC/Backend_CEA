
using Application.Dto.Response.Users;

namespace Application.Dto.Query.Users
{
    public record ListAllUserQuery() : Request<ErrorOr<IReadOnlyList<UserResponse>>>;
}
