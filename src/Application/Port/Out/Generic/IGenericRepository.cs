using Application.Port.Out.Generic;
using Domain.Generics;

namespace Application.Port.Out.Generic
{
    public interface IGenericRepository<TID, T>
        where TID : IGenericId
        where T : GenericEntity<TID>
    {
        IQueryable<T> ListAll();
        Task<T?> FindById(TID id);
        void Create(T entidad);
        void Update(T entidad);
        void Delete(T id);
    }
}
