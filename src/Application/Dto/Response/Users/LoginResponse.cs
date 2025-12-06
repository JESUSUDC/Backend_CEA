

namespace Application.Dto.Response.Users
{
    public record LoginResponse(
        string Token,
        string RefreshToken
    );
}
