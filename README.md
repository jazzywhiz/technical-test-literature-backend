# Literature API

API para gestionar información sobre libros y autores, implementada con arquitectura limpia en .NET 9 y documentación basada en Scalar.

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4)
![C#](https://img.shields.io/badge/C%23-11-239120)
![Architecture](https://img.shields.io/badge/Architecture-Clean-brightgreen)

## 🔍 Descripción del proyecto

Literature es una API RESTful que actúa como intermediario entre aplicaciones frontend y una API externa. El proyecto sigue los principios de Clean Architecture, organizando el código en capas con responsabilidades claramente definidas:

- **Literature.Api**: Capa de presentación con endpoints REST y documentación
- **Literature.Application**: Capa de aplicación con lógica de negocio y objetos de transferencia de datos
- **Literature.Domain**: Capa de dominio con entidades principales y contratos
- **Literature.Infrastructure**: Capa de infraestructura para acceso a servicios externos

## ⚙️ Tecnologías principales

- **ASP.NET Core 9.0**: Framework web moderno y de alto rendimiento
- **Carter**: Biblioteca para organizar endpoints minimalistas de ASP.NET
- **Scalar**: Herramienta para documentación de API que reemplaza a Swashbuckle
- **Mapster**: Biblioteca para mapeo de objetos entre capas
- **FluentValidation**: Validación de modelos basada en fluent interface

## 📋 Requisitos previos

- .NET 6 SDK o superior
- Visual Studio 2022 (17.10+) o Visual Studio Code con extensiones para C#
- Git
- Conexión a Internet para comunicación con APIs externas

## 🚀 Instalación y configuración

### Opción 1: Clonar con Git estándar

```bash
# Clonar el repositorio
git clone https://github.com/jazzywhiz/technical-test-literature-backend.git

# Navegar al directorio
cd technical-test-literature-backend

# Restaurar dependencias
dotnet restore

# Compilar la solución
dotnet build
```

### Opción 2: Usando Visual Studio

1. Abrir Visual Studio 2022
2. Seleccionar "Clonar un repositorio"
3. Introducir la URL del repositorio: `https://github.com/jazzywhiz/technical-test-literature-backend.git`
4. Elegir la ruta de destino y hacer clic en "Clonar"
5. Una vez abierto, hacer clic derecho en la solución y seleccionar "Restaurar paquetes NuGet"

## ⚡ Ejecución del proyecto

### Desde línea de comandos

```bash
# Navegar al proyecto API
cd Literature.Api

# Ejecutar en modo desarrollo
dotnet run

# Opcionalmente, especificar el entorno
dotnet run --environment Development
```

### Desde Visual Studio

1. Establecer "Literature.Api" como proyecto de inicio
2. Seleccionar el perfil de ejecución (https o http)
3. Presionar F5 o hacer clic en el botón "Iniciar"

## 📚 Documentación de la API

La documentación de la API está disponible automáticamente a través de Scalar (reemplazo de Swashbuckle para .NET 9). Una vez en ejecución, puedes acceder a:

- **Documentación interactiva**: `https://localhost:<puerto>/scalar/`
- **Especificación OpenAPI**: `https://localhost:<puerto>/openapi/v1.json`

### Diferencias entre Scalar y Swashbuckle

Scalar es la evolución de Swashbuckle para .NET 9, con mejoras significativas:

- **Rendimiento optimizado**: Genera documentación más rápido
- **Menor huella de memoria**: Usa menos recursos en tiempo de ejecución
- **Integración mejorada**: Mejor soporte para las nuevas funcionalidades de .NET
- **Interfaz más moderna**: UI renovada y experiencia mejorada
- **Mejor soporte para Minimal APIs**: Documentación específica para endpoints minimalistas

## 📡 Endpoints disponibles

### Libros

| Método | Ruta | Descripción | Códigos de respuesta |
|--------|------|-------------|----------------------|
| GET | `/api/books` | Obtiene todos los libros | 200 |
| GET | `/api/books/{id}` | Obtiene un libro por ID | 200, 404 |
| POST | `/api/books` | Crea un nuevo libro | 201, 400 |
| PUT | `/api/books/{id}` | Actualiza un libro existente | 204, 400, 404 |
| DELETE | `/api/books/{id}` | Elimina un libro | 204, 404 |

### Autores

| Método | Ruta | Descripción | Códigos de respuesta |
|--------|------|-------------|----------------------|
| GET | `/api/authors` | Obtiene todos los autores | 200 |
| GET | `/api/authors/{id}` | Obtiene un autor por ID | 200, 404 |
| POST | `/api/authors` | Crea un nuevo autor | 201, 400 |
| GET | `/api/authors/books/{bookId}` | Obtiene todos los datos relacionados a un libro por ID | 200, 404, 500 |
| PUT | `/api/authors/{id}` | Actualiza un autor existente | 204, 400, 404 |
| DELETE | `/api/authors/{id}` | Elimina un autor | 204, 404 |


## 🏗️ Arquitectura y estructura del proyecto

```
LiteratureSolution/
├── Literature.Api/               # Capa de presentación
│   ├── Endpoints/                # Definición de endpoints REST
│   │   ├── AuthorEndpoints.cs    # Endpoints para autores
│   │   └── BookEndpoints.cs      # Endpoints para libros
│   ├── Properties/               # Configuración de lanzamiento
│   ├── appsettings.json          # Configuración principal
│   ├── appsettings.Development.json  # Configuración de desarrollo
│   └── Program.cs                # Punto de entrada y configuración
│
├── Literature.Application/       # Capa de aplicación
│   ├── Contracts/                # Interfaces de servicios
│   ├── Dtos/                     # Objetos de transferencia de datos
│   │   ├── Authors/              # DTOs para autores
│   │   └── Books/                # DTOs para libros
│   ├── Exceptions/               # Excepciones personalizadas
│   ├── Mappings/                 # Configuración de mapeo de objetos
│   ├── Services/                 # Implementaciones de servicios
│   └── Container.cs              # Registro de dependencias
│
├── Literature.Domain/            # Capa de dominio
│   ├── Entities/                 # Entidades del dominio
│   │   ├── Author.cs             # Entidad Autor
│   │   └── Book.cs               # Entidad Libro
│   └── Repositories/             # Interfaces de repositorios
│
├── Literature.Infrastructure/    # Capa de infraestructura
│   ├── Api/                      # Clientes de API
│   ├── Contracts/                # Interfaces de infraestructura
│   ├── Repositories/             # Implementación de repositorios
│   └── Container.cs              # Registro de dependencias
│
└── Literature.Tests/             # Pruebas unitarias
    └── Globals/                  # Configuración global de pruebas
```

## ⚠️ Solución de problemas comunes

### Puertos ya en uso

Si recibes un error indicando que el puerto ya está en uso, puedes:

1. Cambiar los puertos en `launchSettings.json`
2. Detener la aplicación que esté usando ese puerto:
   ```bash
   # En Windows
   netstat -ano | findstr :<puerto>
   taskkill /PID <PID> /F
   
   # En Linux/macOS
   lsof -i :<puerto>
   kill -9 <PID>
   ```

### Problemas con Scalar

Si la documentación de Scalar no se carga correctamente:

1. Asegúrate de que estás ejecutando la aplicación en modo Desarrollo
2. Verifica que el paquete `Scalar.AspNetCore` esté correctamente instalado
3. Comprueba en `Program.cs` que el middleware de Scalar está configurado

```csharp
// En Program.cs
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => {
        options.WithTitle("Literature API");
    });
}
```

## 🔧 Configuración avanzada

### API Externa

La aplicación está configurada para comunicarse con una API externa. La configuración está en `appsettings.json`:

```json
{
  "Api": {
    "BaseAddress": "https://fakerestapi.azurewebsites.net/api/v1/"
  }
}
```

Para cambiar la API externa, modifica la URL en este archivo.

### CORS

La aplicación tiene CORS habilitado con una política permisiva para desarrollo. En producción, deberías restringir los orígenes permitidos.

## 📄 Licencia

Este proyecto está licenciado bajo [MIT License](LICENSE.txt).
