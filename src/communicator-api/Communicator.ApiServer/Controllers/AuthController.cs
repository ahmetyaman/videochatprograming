using Communicator.ApiServer.Dtos;
using Communicator.Application.Queries;
using Communicator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Communicator.ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator, ILogger<AuthController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(PersonResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<PersonResponse>> Login([FromBody] PersonForLoginDto personForLoginDto)
        {
            var query = new GetPersonByEmailAndPasswordQuery(personForLoginDto.Email, personForLoginDto.Password);

            var person = await _mediator.Send(query);
            if (person == null)
                return Unauthorized(); 

            return Ok(person);
        }
    }
}