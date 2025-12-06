
using Application.Dto.Command.Users;
using Application.Port.In.Users;
using Application.Port.Out.Jwt;
using Application.Port.Out.UnitOfWork;
using Application.Port.Out.Users;
using Domain.Users.Entity;

namespace Application.Service.Users
{
    public class CreateUserService : ICreateUserUseCase
    {
        public IUserRepositoryPort _userRepositoryPort;
        public ITokenIssue _tokenIssue;
        public IUnitOfWork _unitOfWork;

        public CreateUserService(IUserRepositoryPort userRepositoryPort, ITokenIssue tokenIssue, IUnitOfWork unitOfWork)
        {
            _userRepositoryPort = userRepositoryPort;
            _tokenIssue = tokenIssue;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> CreateUser(CreateUserCommand command)
        {
            if (await _userRepositoryPort.FindByUserName(command.UserName) is User user)
            {
                return Error.Conflict("Usuario.Encontrado", "Ya existe un usuario con ese nombre de usuario.");
            }

            var newUser = new User(
                   new UserId(Guid.NewGuid()),
                   command.Name,
                   command.LastName,
                   command.UserName,
                   _tokenIssue.EncryptSHA256(command.Password)
            );
            
            _userRepositoryPort.Create(newUser);
            
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
