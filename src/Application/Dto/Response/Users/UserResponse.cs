

using Application.Dto.Response.Cellphones;

namespace Application.Dto.Response.Users
{
    public record UserResponse(
        Guid Id,
        string Name,
        string LastName,
        string UserName,
        List<CellphoneResponse> Cellphones
    );

}
