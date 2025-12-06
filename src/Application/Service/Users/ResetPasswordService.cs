
using Application.Dto.Command.Users;
using Application.Port.In.Users;
using Application.Port.Out.Jwt;
using Application.Port.Out.UnitOfWork;
using Application.Port.Out.Users;
using Domain.Users.Entity;

namespace Application.Service.Users
{
    public class ResetPasswordService : IResetPasswordUseCase
    {
        public IUserRepositoryPort _userRepositoryPort;
        public ITokenIssue _tokenIssue;
        public IUnitOfWork _unitOfWork;

        public ResetPasswordService(IUserRepositoryPort userRepositoryPort, ITokenIssue tokenIssue, IUnitOfWork unitOfWork)
        {
            _userRepositoryPort = userRepositoryPort;
            _tokenIssue = tokenIssue;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> ResetPassword(ResetPasswordCommand command)
        {
            if (await _userRepositoryPort.FindById(new UserId(command.Id)) is not User user)
            {
                return Error.NotFound("Usuario.Encontrado", "No se encontro el usuario.");
            }

            if (!user.CheckPassword(_tokenIssue.EncryptSHA256(command.OldPassword)))
            {
                return Error.Validation("Usuario.Contraseña", "La contraseña actual es incorrecta.");
            }

            user.ResetPassword(_tokenIssue.EncryptSHA256(command.NewPassword));

            _userRepositoryPort.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
