
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Servicios
{
    public static class InyeccionDeDependencias
    {
        public static IServiceCollection AddPresentation(this IServiceCollection servicios, IConfiguration configuracion)
        {
            servicios.AddControllers();
            servicios.AddEndpointsApiExplorer();
            servicios.AddOpenApi();
            servicios.AddTransient<GlobalExceptionHandlingMiddleware>();

            servicios.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuracion["Jwt:Audience"],
                    ValidIssuer = configuracion["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuracion["Jwt:Key"]!))
                };
            });

            servicios.AddCors(options =>
            {
                
                options.AddPolicy("web", policyBuilder =>
                {
                    policyBuilder.WithOrigins(
                        "http://localhost:4200",
                        "https://localhost:4200",
                        "https://localhost:8500",
                        "https://localhost:80"
                        );
                    policyBuilder.AllowAnyHeader();
                    policyBuilder.AllowAnyMethod();
                    policyBuilder.AllowCredentials();
                });
                

                /*options.AddPolicy("web", policyBuilder =>
                {
                    policyBuilder.AllowAnyOrigin();
                    policyBuilder.AllowAnyHeader();
                    policyBuilder.AllowAnyMethod();
                });*/

            });

            return servicios;
        }
    }
}
