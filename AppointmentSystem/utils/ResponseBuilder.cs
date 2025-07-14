using System.Net;
using AppointmentSystem.Models.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.Utils
{
    public static class ResponseBuilder
    {
        public static IActionResult Build(HttpStatusCode statusCode, string message, object data = null)
        {
            var response = new GeneralResponseDTO(message, data);
            return new ObjectResult(response)
            {
                StatusCode = (int)statusCode
            };
        }

        public static IActionResult Ok(string message, object data = null)
            => Build(HttpStatusCode.OK, message, data);

        public static IActionResult NotFound(string message)
            => Build(HttpStatusCode.NotFound, message);

        public static IActionResult Conflict(string message)
            => Build(HttpStatusCode.Conflict, message);

        public static IActionResult BadRequest(string message)
            => Build(HttpStatusCode.BadRequest, message);
    }
}