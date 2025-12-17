using FluentValidation;
using Gradiscent.Application.Common.Models;
using System.Net;
using System.Text.Json;

namespace Gradiscent.Api.Middleware
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(ValidationException ex)
            {
                await HandleValidationExceptionAsync(context, ex);
            }
        }

        public async Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var errors = ex.Errors.Select(e => e.ErrorMessage).ToList();

            var response = ApiResponse.Fail("Validation Failed", errors);

            var json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }
    }
}
