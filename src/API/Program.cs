using Application.Servicios;
using API.Extensiones;
using API.Middlewares;
using API.Servicios;
using Infrastructure.Servicios;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentation(builder.Configuration)
                .AddInfrastructura(builder.Configuration)
                .AddAplication();

var environment = builder.Environment.EnvironmentName;
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

Console.WriteLine($"Entorno actual: {builder.Environment.EnvironmentName}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseCors("web");

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();