
using Application.Dto.Command.Users;

namespace Application.Port.In.Users
{
    public interface IDeleteUserUseCase
    {
        public Task<ErrorOr<Unit>> DeleteUser(DeleteUserCommand command);
    }
}
