using Domain.Cellphones.Entity;
using Application.Port.Out.Generic;

namespace Application.Port.Out.Cellphones
{
    public interface ICellphoneRepositoryPort : IGenericRepository<CellphoneId, Cellphone>
    {
    }
}
