
using Application.Dto.Response.Users;

namespace Application.Dto.Query.Users
{
    public record LoginQuery(string Username, string Password) : IRequest<ErrorOr<LoginResponse>>;
}
