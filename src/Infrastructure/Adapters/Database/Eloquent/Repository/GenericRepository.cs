

using Domain.Generics;
using Infrastructure.Adapters.Database.Eloquent.UnitOfWork;

namespace Infrastructure.Adapters.Database.Eloquent.Repository
{
    public class GenericRepository<TID, T> : IGenericRepository<TID, T>
        where TID : IGenericId
        where T : GenericEntity<TID>
    {
        protected readonly AplicacionContextoDb _contexto;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AplicacionContextoDb contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
            _dbSet = _contexto.Set<T>();
        }

        public void Update(T entidad) => _dbSet.Update(entidad);

        public async void Create(T entidad) => await _dbSet.AddAsync(entidad);

        public void Delete(T id) => _dbSet.Remove(id);

        public async Task<T?> FindById(TID id) => await _dbSet.FindAsync(id);

        public IQueryable<T> ListAll() => _dbSet.OrderBy(t => t.UpdateAt);
    }
}
