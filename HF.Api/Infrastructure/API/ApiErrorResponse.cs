using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HF.Api.Infrastructure
{
    public class ApiErrorResponse : ApiResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, Order = int.MaxValue)]
        public string? StackTrace { get; set; }

        public ApiErrorResponse(string message)
            : base(StatusCodes.Status500InternalServerError, message)
        {
        }
    }
}
