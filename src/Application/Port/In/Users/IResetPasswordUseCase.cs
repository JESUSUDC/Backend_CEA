
using Application.Dto.Command.Users;

namespace Application.Port.In.Users
{
    public interface IResetPasswordUseCase
    {
        public Task<ErrorOr<Unit>> ResetPassword(ResetPasswordCommand command);
    }
}
