# FarmaciaV1Api

Web API desarrollada con ASP.NET Core para la gestión del inventario de una farmacia.

## Tecnologías
- ASP.NET Core Web API (.NET 10)
- Entity Framework Core + SQLite
- Arquitectura modular: Controller → Service → Repository → DbContext

## Estructura
```
Modules/
 └── Medicamentos/
      ├── Controllers/
      ├── Dtos/
      ├── Entities/
      ├── Repositories/
      ├── Services/
      └── MedicamentosModule.cs
```

## Endpoints

| Método | Ruta | Respuestas |
|---|---|---|
| GET | /medicamentos | 200 |
| GET | /medicamentos/{id} | 200, 404 |
| POST | /medicamentos | 201, 400 |
| PATCH | /medicamentos/{id} | 200, 400, 404 |
| DELETE | /medicamentos/{id} | 200, 404 |

## Ejecución
```
dotnet restore
dotnet ef database update
dotnet run
```