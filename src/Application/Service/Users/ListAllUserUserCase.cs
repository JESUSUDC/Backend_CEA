
using Application.Dto.Query.Users;
using Application.Mapper;
using Application.Port.In.Users;
using Application.Port.Out.Users;

namespace Application.Service.Users
{
    public class ListAllUserUserCase : IListAllUserUseCase
    {
        public IUserRepositoryPort _userRepositoryPort;

        public ListAllUserUserCase(IUserRepositoryPort userRepositoryPort)
        {
            _userRepositoryPort = userRepositoryPort;
        }

        public async Task<ErrorOr<IReadOnlyList<UserResponse>>> ListAllUsers(ListAllUserQuery query)
        {
            var users = await _userRepositoryPort.ListAll();
            var userResponses = users.Select(user => UserMapper.Map(user))
                .ToList();

            return userResponses;
        }
    }
}
