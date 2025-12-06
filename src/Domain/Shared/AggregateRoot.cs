namespace Domain.Shared;

public abstract class AggregateRoot
{
    private readonly List<DomainEvent> _eventosDeDominio = new();

    public ICollection<DomainEvent> GetDomainEvents() => _eventosDeDominio;

    protected void Raise(DomainEvent eventoDeDominio)
    {
        _eventosDeDominio.Add(eventoDeDominio);
    }
}
