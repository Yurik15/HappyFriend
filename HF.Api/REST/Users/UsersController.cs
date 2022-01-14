using AutoMapper;
using HF.Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HF.Api.REST.Users
{
    [Route("api/v1/users")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(
            IMediator mediator,
            IMapper mapper
            )
            : base(mediator,
                   mapper)
        {

        }

        [HttpGet]
        [Route("orders")]
        public IActionResult GetUserOrders() 
        {
            return Ok();
        }
    }
}
