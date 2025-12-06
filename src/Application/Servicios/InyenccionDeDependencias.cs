using Application.comun.Behaviors;
using Application.Port.In.Cellphones;
using Application.Port.In.Users;
using Application.Port.Out.Jwt;
using Application.Service.Cellphones;
using Application.Service.Users;
using Application.Servicios;
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

            // Cellphone services
            servicios.AddScoped<ICreateCellphoneUseCase, CreateCellphoneService>();
            servicios.AddScoped<IDeleteCellphoneUseCase, DeleteCellphoneService>();
            servicios.AddScoped<IUpdateCellphoneUseCase, UpdateCellphoneService>();
            servicios.AddScoped<IFindByIdCellphoneUseCase, FindByIdCellphoneService>();
            servicios.AddScoped<IListAllCellphoneUseCase, ListAllCellphoneService>();

            // User services
            servicios.AddScoped<ICreateUserUseCase, CreateUserService>();
            servicios.AddScoped<IDeleteUserUseCase, DeleteUserService>();
            servicios.AddScoped<IUpdateUserUseCase, UpdateUserService>();
            servicios.AddScoped<IFindByIdUserUserCase, FindByIdUserService>();
            servicios.AddScoped<IListAllUserUseCase, ListAllUserService>();
            servicios.AddScoped<ILoginUseCase, LoginService>();
            servicios.AddScoped<IRefreshTokenUseCase, RefreshTokenService>();
            servicios.AddScoped<IResetPasswordUseCase, ResetPasswordService>();
            servicios.AddScoped<IUserDataUseCase, UserDataService>();



            return servicios;
        }
    }
}
