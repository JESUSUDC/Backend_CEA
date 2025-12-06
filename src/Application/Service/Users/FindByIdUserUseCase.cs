
using Application.Mapper;
using Application.Port.In.Users;
using Application.Port.Out.Users;

namespace Application.Service.Users
{
    public class FindByIdUserUseCase : IFindByIdUserUserCase
    {
        public IUserRepositoryPort _userRepositoryPort;

        public FindByIdUserUseCase(IUserRepositoryPort userRepositoryPort)
        {
            _userRepositoryPort = userRepositoryPort;
        }

        public async Task<ErrorOr<UserResponse>> FindByIdUser(FinByIdUserQuery query)
        {
            if (await _userRepositoryPort.FindById(new UserId(query.Id)) is User user)
            {
                return Error.NotFound("Usuario.Encontrado", "No se encontro el usuario.");
            }

            return UserMapper.Map(user);
        }
    }
}
