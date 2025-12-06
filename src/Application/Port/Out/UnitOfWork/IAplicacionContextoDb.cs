using Domain.Users.Entity;
using Domain.Cellphones.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Port.Out.UnitOfWork
{
    public interface IAplicacionContextoDb
    {
        public DbSet<User> User { get; set; }
        public DbSet<Cellphone> Cellphone { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
