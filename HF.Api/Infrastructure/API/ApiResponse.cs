using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HF.Api.Infrastructure
{
    public class ApiResponse
    {
        [JsonProperty(Order = 1)]
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, Order = 2)]
        public string? Message { get; }

        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string? GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case StatusCodes.Status200OK:
                case StatusCodes.Status204NoContent:
                    return "OK";
                case StatusCodes.Status400BadRequest:
                    return "Bad Request";
                case StatusCodes.Status401Unauthorized:
                    return "Unauthorized";
                case StatusCodes.Status403Forbidden:
                    return "Forbidden";
                case StatusCodes.Status404NotFound:
                    return "Resource not found";
                case StatusCodes.Status409Conflict:
                    return "A request conflict with current state of the server occured";
                case StatusCodes.Status500InternalServerError:
                    return "An unhandled error occurred";
                default:
                    return null;
            }
        }
    }
}
