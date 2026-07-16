using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using TaskManagerApi_03.Domain.Exceptions;

namespace TaskManagerApi_03.Infrastructure
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        private readonly IHostEnvironment _env;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }
        public async ValueTask<bool> TryHandleAsync(
      HttpContext httpContext,
      Exception exception,
      CancellationToken cancellationToken)
        {
            // 1. Generar o recuperar el TraceId (Activity.Current es la buena práctica en .NET)
            var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

            // 2. Mapeo HTTP según tus 3 casos de uso básicos
            var (statusCode, title) = exception switch
            {
                DomainException => (StatusCodes.Status400BadRequest, "Error de validación de negocio"),
                ConflictException => (StatusCodes.Status409Conflict, "Conflicto en el estado del recurso"),
                NotFoundException => (StatusCodes.Status404NotFound, "Recurso no encontrado"),
                _ => (StatusCodes.Status500InternalServerError, "Error interno del servidor")
            };

            // 3. Logging con el mismo formato que ya tenías definido
            if (statusCode == StatusCodes.Status500InternalServerError)
            {
                _logger.LogError(exception, "Error crítico [{TraceId}]: {Message}", traceId, exception.Message);
            }
            else
            {
                _logger.LogWarning("Advertencia de negocio [{TraceId}]: {Message}", traceId, exception.Message);
            }

            // 4. Crear la estructura estándar ProblemDetails usando tus condiciones de entorno
            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

            // Añadimos extensiones personalizadas para el TraceId y el StackTrace
            problemDetails.Extensions.Add("traceId", traceId);

            if (_env.IsDevelopment())
            {
                problemDetails.Extensions.Add("developmentDetails", exception.StackTrace);
            }
            else
            {
                problemDetails.Extensions.Add("developmentDetails", "Contacte al administrador.");
            }

            // 5. Configurar la respuesta HTTP y enviar el JSON optimizado
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/problem+json"; // Estándar de la industria para errores

            await httpContext.Response.WriteAsJsonAsync(
                problemDetails,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase },
                cancellationToken);

            // Retornar true le dice a .NET que el error ya fue manejado correctamente
            return true;
        }
    }
}
