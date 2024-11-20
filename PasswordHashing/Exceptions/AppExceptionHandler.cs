using Microsoft.AspNetCore.Diagnostics;
using PasswordHashing.Models;
using System.ComponentModel.DataAnnotations;

namespace PasswordHashing.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
            CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if (exception is ValidationException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.ExceptionMessage = exception.Message;
                response.Title = "Invalid input";
            }
            else if (exception is UserNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Wrong input";
            }
            else if (exception is UserAlreadyExistException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.ExceptionMessage = exception.Message;
                response.Title = "Wrong input";
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.ExceptionMessage = exception.Message;
                response.Title = "Something went wrong";
            }
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
