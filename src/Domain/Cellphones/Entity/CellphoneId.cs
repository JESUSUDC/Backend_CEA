
using Domain.Generics;

namespace Domain.Cellphones.Entity
{
    public record CellphoneI(Guid Value) : IGenericId
    {
    }
}
