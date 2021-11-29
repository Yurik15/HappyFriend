using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HF.Api.Infrastructure
{
    public class ApiConflictResponse<T> : ApiResponse
    {
        [JsonProperty("values")]
        public IEnumerable<T> Values { get; }
        public string Type { get; set; }
        public ApiConflictResponse(IEnumerable<T> values, string type, string message)
            : base(StatusCodes.Status409Conflict, message)
        {
            Values = values ?? throw new ArgumentNullException(nameof(values));
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }
    }
}
