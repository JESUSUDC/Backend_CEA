
using Domain.Generics;

namespace Domain.Cellphones.Entity
{
    public record CellphoneId(Guid Value) : IGenericId;
}
