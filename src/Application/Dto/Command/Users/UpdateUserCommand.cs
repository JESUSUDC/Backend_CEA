
namespace Application.Dto.Command.Users
{
    public record UpdateUserCommand(
        Guid Id,
        string Name,
        string LastName,
        string UserName,
        string Password
    ) : IRequest<ErrorOr<Unit>>;
}
