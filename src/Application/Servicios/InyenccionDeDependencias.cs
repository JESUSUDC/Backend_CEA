using Application.comun.Behaviors;
using Application.Port.Out.Jwt;
using Application.Servicios;
using Application.Utilidades;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Servicios
{
    public static class InyenccionDeDependencias
    {
        public static IServiceCollection AddAplication(this IServiceCollection servicios)
        {
            servicios.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
            });

            servicios.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidacionBehavior<,>)
            );

            servicios.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();

            servicios.AddHttpContextAccessor();

            servicios.AddScoped<ITokenIssue, GestionToken>();

            return servicios;
        }
    }
}
