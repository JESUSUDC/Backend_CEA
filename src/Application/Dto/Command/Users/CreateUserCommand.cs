
namespace Application.Dto.Command.Users
{
    public record CreateUserCommand(
        string Name,
        string LastName,
        string UserName,
        string Password
    ) : IRequest<ErrorOr<Unit>>;
}
