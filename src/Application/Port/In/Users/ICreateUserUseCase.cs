
using Application.Dto.Command.Users;

namespace Application.Port.In.Users
{
    public interface ICreateUserUseCase
    {
        public Task<ErrorOr<Unit>> CreateUser(CreateUserCommand command);
    }
}
