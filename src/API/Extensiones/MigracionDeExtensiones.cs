
using Infrastructure.Adapters.Database.Eloquent.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace API.Extensiones
{
    public static class MigracionDeExtensiones
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
              
            var dbContext = scope.ServiceProvider.GetRequiredService<AplicacionContextoDb>();

            dbContext.Database.Migrate();
        }
    }
}
