
using Application.Dto.Command.Users;
using Application.Port.In.Users;
using Application.Port.Out.UnitOfWork;
using Application.Port.Out.Users;
using Domain.Users.Entity;

namespace Application.Service.Users
{
    public class DeleteUserService : IDeleteUserUseCase
    {
        public IUserRepositoryPort _userRepositoryPort;
        public IUnitOfWork _unitOfWork;

        public DeleteUserService(IUserRepositoryPort userRepositoryPort, IUnitOfWork unitOfWork)
        {
            _userRepositoryPort = userRepositoryPort;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> DeleteUser(DeleteUserCommand command)
        {
            if (await _userRepositoryPort.FindById(new UserId(command.Id)) is not User user)
            {
                return Error.NotFound("Usuario.Encontrado", "No se encontro el usuario.");
            }

            _userRepositoryPort.Delete(user);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
