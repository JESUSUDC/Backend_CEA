

using Application.Port.Out.Users;
using Domain.Users.Entity;
using Infrastructure.Adapters.Database.Eloquent.UnitOfWork;

namespace Infrastructure.Adapters.Database.Eloquent.Repository
{
    public class UserRepository : GenericRepository<UserId, User>, IUserRepositoryPort
    {
        public UserRepository(AplicacionContextoDb contexto) : base(contexto)
        {
        }

        public async Task<User?> Login(string userName, string password)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserName == userName && u.PasswordHash == password);
        }

        public async Task<User?> FindByUserName(string userName)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
