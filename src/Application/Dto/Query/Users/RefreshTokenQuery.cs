
using Application.Dto.Response.Users;

namespace Application.Dto.Query.Users
{
    public record RefreshTokenQuery() : IRequest<ErrorOr<LoginResponse>>;
}
