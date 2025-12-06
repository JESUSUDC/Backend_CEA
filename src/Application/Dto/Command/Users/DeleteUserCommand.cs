
namespace Application.Dto.Command.Users
{
    public record DeleteUserCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
