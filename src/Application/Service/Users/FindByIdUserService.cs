
using Application.Dto.Query.Users;
using Application.Dto.Response.Users;
using Application.Mapper;
using Application.Port.In.Users;
using Application.Port.Out.Users;
using Domain.Users.Entity;

namespace Application.Service.Users
{
    public class FindByIdUserService : IFindByIdUserUserCase
    {
        public IUserRepositoryPort _userRepositoryPort;

        public FindByIdUserService(IUserRepositoryPort userRepositoryPort)
        {
            _userRepositoryPort = userRepositoryPort;
        }

        public async Task<ErrorOr<UserResponse>> FindByIdUser(FindByIdUserQuery query)
        {
            if (await _userRepositoryPort.FindById(new UserId(query.Id)) is not User user)
            {
                return Error.NotFound("Usuario.Encontrado", "No se encontro el usuario.");
            }

            return UserMapper.Map(user);
        }
    }
}
