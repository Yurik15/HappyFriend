using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HF.Api.Infrastructure
{
    [Produces("application/json")]
    [ApiController]
    [ProducesResponseType(typeof(ApiBadRequestResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IMediator Mediator { get; }
        protected IMapper Mapper { get; }

        public ApiControllerBase(
            IMediator mediator,
            IMapper mapper)
        {
            Mediator = mediator;
            Mapper = mapper;
        }
    }
}
