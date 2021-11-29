using AutoMapper;
using HF.Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HF.Api.REST.Example
{
    [Route("api/v1/example")]
    public class ExampleController : ApiControllerBase
    {
        public ExampleController(
            IMediator mediator,
            IMapper mapper
            )
            : base(mediator,
                   mapper)
        {

        }
    }
}
