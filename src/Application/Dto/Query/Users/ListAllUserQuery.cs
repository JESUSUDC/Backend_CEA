
using Application.Dto.Response.Users;

namespace Application.Dto.Query.Users
{
    public record ListAllUserQuery() : IRequest<ErrorOr<IReadOnlyList<UserResponse>>>;
}
