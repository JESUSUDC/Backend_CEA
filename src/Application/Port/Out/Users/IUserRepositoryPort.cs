using Domain.Users.Entity;
using Application.Port.Out.Generic;

namespace Application.Port.Out.Users
{
    public interface IUserRepositoryPort : IGenericRepository<UserId, User>
    {
        public Task<User?> Login(string userName, string password);
        public async Task<User?> FindByUserName(string userName);
    }
}
