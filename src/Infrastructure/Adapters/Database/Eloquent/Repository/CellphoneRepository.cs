
using Application.Port.Out.Cellphones;
using Domain.Cellphones.Entity;
using Infrastructure.Adapters.Database.Eloquent.UnitOfWork;

namespace Infrastructure.Adapters.Database.Eloquent.Repository
{
    public class CellphoneRepository : GenericRepository<CellphoneId, Cellphone>, ICellphoneRepositoryPort
    {
        public CellphoneRepository(AplicacionContextoDb contexto) : base(contexto)
        {
        }
    }
}
