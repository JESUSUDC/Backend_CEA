
namespace Domain.Generics
{
    public interface IGenericRepository<TID, T>
        where TID : IIdGeneric
        where T : EntidadGeneric<TID>
    {
        IQueryable<T> ListAll();
        Task<T?> FindById(TID id);
        void Create(T entidad);
        void Update(T entidad);
        void Delete(T id);
    }
}
