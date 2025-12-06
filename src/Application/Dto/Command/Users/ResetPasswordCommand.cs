
namespace Application.Dto.Command.Users
{
    public record ResetPasswordCommand(Guid Id, string OldPassword, string NewPassword) : IRequest<ErrorOr<Unit>>;
}
