

using Infrastructure.Adapters.Database.Eloquent.UnitOfWork;

namespace Infrastructure.Adapters.Database.Eloquent.Repository
{
    public class UserRepository : GenericRepository<UserId, User>, IUserRepository
    {
        public RepositorioUsuario(AplicacionContextoDb contexto) : base(contexto)
        {
        }

        public async Task<User?> Login(string userName, string password)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
        }

        public async Task<User?> FindByUserName(string userName)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
