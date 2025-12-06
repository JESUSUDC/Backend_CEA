using Domain.Generics;

namespace Domain.Users.Entity
{
    public record UserId(Guid Value) : IGenericId;
}
