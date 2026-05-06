using ContactManagement.DAL.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using WebApplication3.Models;

namespace WebApplication3.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = StatusCodes.Status500InternalServerError;
            string message = "Something went wrong";

            if (exception is NotFoundException)
            {
                statusCode = StatusCodes.Status404NotFound;
                message = exception.Message;
            }
            else if (exception is ArgumentException)
            {
                statusCode = StatusCodes.Status400BadRequest;
                message = exception.Message;
            }

            ErrorResponse error = new ErrorResponse
            {
                Message = message,
                StatusCode = statusCode,
                Timestamp = DateTime.Now
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            string json = JsonSerializer.Serialize(error);
            await context.Response.WriteAsync(json);
        }
    }
}
