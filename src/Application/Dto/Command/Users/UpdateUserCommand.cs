
namespace Application.Dto.Command.Users
{
    public record UpdateUserCommand(
        Guid Id,
        string Name,
        string LastName,
        string UserName
    ) : IRequest<ErrorOr<Unit>>;
}
