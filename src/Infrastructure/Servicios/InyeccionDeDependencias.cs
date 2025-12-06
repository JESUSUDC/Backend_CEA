
using Application.Port.Out.Cellphones;
using Application.Port.Out.Jwt;
using Application.Port.Out.UnitOfWork;
using Application.Port.Out.Users;
using Infrastructure.Adapters.Database.Eloquent.Repository;
using Infrastructure.Adapters.Database.Eloquent.UnitOfWork;
using Infrastructure.Security.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Servicios
{
    public static class InyeccionDeDependencias
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection servicios, IConfiguration configuracion)
        {
            servicios.AgregarPersistencias(configuracion);
            return servicios;
        }

        public static IServiceCollection AgregarPersistencias(this IServiceCollection servicios, IConfiguration configuracion)
        {
            servicios.AddDbContext<AplicacionContextoDb>(options =>
                options.UseSqlServer(configuracion.GetConnectionString("Database"), sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null);
                }));

            servicios.AddScoped<IAplicacionContextoDb>(sp =>
                sp.GetRequiredService<AplicacionContextoDb>());

            servicios.AddScoped<IUnitOfWork>(sp =>
                sp.GetRequiredService<AplicacionContextoDb>());

            servicios.AddHttpContextAccessor();

            servicios.AddScoped<ITokenIssue, TokenIssue>();

            servicios.AddScoped<ICellphoneRepositoryPort, CellphoneRepository>();
            servicios.AddScoped<IUserRepositoryPort, UserRepository>();

            return servicios;
        }

    }
}
