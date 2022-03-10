using Communicator.Application.Commands.PersonCreate;
using Communicator.Application.Queries;
using Communicator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Communicator.ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IMediator mediator, ILogger<PersonController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PersonResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PersonResponse>> PersonCreate([FromBody] PersonCreateCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("GetPersonByName/{name}")]
        [ProducesResponseType(typeof(IEnumerable<PersonResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<PersonResponse>>> GetPersonByName(string name)
        {

            var query = new GetPersonByNameQuery(name);

            var persons = await _mediator.Send(query);

            if (persons.Count() == decimal.Zero)
                return NotFound();

            return Ok(persons);

        }

        [HttpGet("GetAllPerson")]
        [ProducesResponseType(typeof(IEnumerable<PersonResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async  Task<ActionResult<IEnumerable<PersonResponse>>> GetAllPerson()
        {
            var query = new GetAllPersonQuery();
            var persons = await _mediator.Send(query);

            if (persons.Count() == decimal.Zero)
                return NotFound();


            return Ok(persons);
        }


        [HttpGet("GetPersonById")]
        [ProducesResponseType(typeof(PersonResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<PersonResponse>> GetPersonById(int Id)
        {
            var query = new GetPersonByIdQuery(Id);
            var person = await _mediator.Send(query);
            if (person == null)
                return NotFound();

            return Ok(person);

        }
    }
}