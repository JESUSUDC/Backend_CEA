
using Application.Dto.Command.Users;
using Application.Port.In.Users;
using Application.Port.Out.UnitOfWork;
using Application.Port.Out.Users;
using Domain.Users.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Service.Users
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        public IUserRepositoryPort _userRepositoryPort;
        public IUnitOfWork _unitOfWork;

        public UpdateUserUseCase(IUserRepositoryPort userRepositoryPort, IUnitOfWork unitOfWork)
        {
            _userRepositoryPort = userRepositoryPort;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> UpdateUser(UpdateUserCommand command)
        {
            if (await _userRepositoryPort.FindById(new UserId(command.Id)) is not User user)
            {
                return Error.NotFound("Usuario.Encontrado", "No se encontro el usuario.");
            }

            if (await _userRepositoryPort.FindByUserName(command.UserName) is User user2 && !user.UserName.Equals(command.UserName))
            {
                return Error.Conflict("Usuario.Encontrado", "Ya existe un usuario con ese nombre de usuario.");
            }

            user.Update(
                command.Name,
                command.LastName,
                command.UserName
            );

            _userRepositoryPort.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }

    }
}
