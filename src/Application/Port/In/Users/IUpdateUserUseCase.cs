
using Application.Dto.Command.Users;

namespace Application.Port.In.Users
{
    public interface IUpdateUserUseCase
    {
        public Task<ErrorOr<Unit>> UpdateUser(UpdateUserCommand command);
    }
}
