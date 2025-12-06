# Backend - CEA: Gestión de Usuarios y Celulares

## Descripción del Proyecto

Backend para la aplicación CEA de gestión de usuarios y celulares. Implementa una API REST siguiendo la **Arquitectura Limpia (Clean Architecture)** y principios de DDD, separando claramente las capas de Presentación, Aplicación, Infraestructura y Dominio. Usa MediatR para CQRS, FluentValidation para validaciones y Entity Framework Core para persistencia.

---

## Tecnologías y versiones (referencia)

- Lenguaje: C# 14.0
- SDK: .NET 10 SDK (instala la última 10.x disponible; comprueba con `dotnet --info`)
- Gestor de paquetes: NuGet (dotnet CLI)
- Framework objetivo: .NET 10
- Librerías principales:
  - Microsoft.EntityFrameworkCore (EF Core) — compatible con .NET 10 
  - Microsoft.EntityFrameworkCore.Design
  - MediatR
  - FluentValidation
  - ErrorOr
- Motor de base de datos: SQL Server / Azure SQL (SQL Server 2019+ recomendado)
- Utilidades para pruebas:
  - Cliente HTTP: Postman (recomendado)
  - IDE: Visual Studio 2026 / Visual Studio Code


---

## Estructura del proyecto

- src/API — capa de presentación (controladores, middlewares, OpenAPI)
- src/Application — capa de aplicación (casos de uso, DTOs, validadores, mapeos)
- src/Domain — entidades, value objects, reglas de negocio
- src/Infrastructure — persistencia, EF Core models, repositorios, UnitOfWork, servicios externos


---

## Migraciones (EF Core)

Se recomienda crear y guardar las migraciones en el proyecto `src/Infrastructure` (el DbContext está en `Infrastructure`).

1. Instalar la herramienta CLI (si no está):

   ```sh
   dotnet tool install --global dotnet-ef
   ```

2. Añadir el paquete de diseño si falta (ejecutar desde la raíz o desde `src/Infrastructure`):

    ```sh
   dotnet add src/Infrastructure package Microsoft.EntityFrameworkCore.Design
   ```

3. Crear una nueva migración (ejemplo nombre: `InitialCreate`). Indicar el proyecto que contiene el `DbContext` con `--project` y el proyecto de arranque con `--startup-project` (normalmente `src/API`). Guardar la migración en la carpeta de Migrations dentro de Infrastructure:

   ```sh
   dotnet ef migrations add InitialCreate --project src/Infrastructure --startup-project src/API
   ```

4. Aplicar las migraciones a la base de datos:
   ```sh
   dotnet ef database update --project src/Infrastructure --startup-project src/API
   ```


Equivalente en Package Manager Console de Visual Studio:
- Seleccione el `Default project` correcto (src.Infrastructure).
- Ejecutar:
  - `Add-Migration InitialCreate -OutputDir Adapters/Database/Eloquent/Migrations -Project src/Infrastructure -StartupProject src/API`
  - `Update-Database -Project src/Infrastructure -StartupProject src/API`

Si necesita ejecutar migraciones contra Azure SQL, asegúrese de que la cadena de conexión en `src/API/appsettings.json` apunte al servidor correcto.

---

## Comandos: crear, compilar y ejecutar

Desde la raíz del repo:

1. Restaurar paquetes:
    ```sh
   dotnet restore
   ```
    
2. Compilar:
    ```sh
   dotnet build
   ```

3. (Opcional) Ejecutar migraciones (ver sección Migraciones arriba):
    ```sh
   dotnet ef database update --project src/Infrastructure --startup-project src/API
   ```

4. Ejecutar la API (proyecto de inicio `src/API`):
    ```sh
   dotnet run --project src/API
   ```


La API quedará disponible en los puertos configurados (ver `appsettings.Development.json` y salida de `dotnet run`).

---

## Docker (opcional)

1. Construir:
    ```sh
   docker-compose build
   ```

2. Levantar:
    ```sh
   docker-compose up -d
   ```

La API en Docker suele exponerse en `http://localhost:8080` según la configuración de `docker-compose`.

---

## Endpoints principales (resumen)

Usuarios
- POST /user            — Crear usuario
- PUT /user             — Actualizar usuario
- DELETE /user/{id}     — Eliminar usuario
- GET /user/{id}        — Obtener usuario por id
- GET /user             — Listar usuarios
- POST /user/reset-password — Resetear contraseña

Celulares
- POST /cellphone       — Crear celular
- PUT /cellphone        — Actualizar celular
- DELETE /cellphone/{id}— Eliminar celular
- GET /cellphone/{id}   — Obtener celular por id
- GET /cellphone        — Listar celulares

(Ver contratos DTO en `src/Application/Dto/...` para la estructura JSON esperada.)

---

## Pruebas y cliente HTTP

Se recomienda usar Postman para probar los endpoints. Crear colecciones con los JSON de ejemplo para:
- Crear/Actualizar Usuario
- Login / Refresh token
- Crear/Actualizar Celular

Autenticación: la API usa JWT; obtenga token con el endpoint de autenticación y añádalo en la cabecera `Authorization: Bearer <token>`.

---

## Contribuir

1. Fork del repositorio.
2. Crear rama `feature/<descripcion>`.
3. Abrir Pull Request con descripción y pruebas.

---

Si quieres, actualizo este README con versiones exactas (ej.: EF Core, MediatR, FluentValidation) leyendo `Directory.Build.props` o `*.csproj` del repo. ¿Deseas que lo haga?

