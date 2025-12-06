using Domain.Shared;

namespace Domain.Generics
{
    public abstract class GenericEntity<TID> : AggregateRoot
        where TID : IIdGenerico
    {
        
        public TID Id { get; protected set; } = default!;
        public DateTime CreateAt { get; protected set; }
        public DateTime UpdateAt { get; protected set; }

        public GenericEntity()
        {
        }

        public GenericEntity(TID id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        
    }
}
