using Communicator.ApiServer.Dtos;
using Communicator.Application.Queries;
using Communicator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Communicator.ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ChatController> _logger;

        public ChatController(IMediator mediator, ILogger<ChatController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("GetChatByGroupName")]
        [ProducesResponseType(typeof(IEnumerable<ChatResponse>),(int) HttpStatusCode.OK )]

        public async Task<ActionResult <IEnumerable<ChatResponse>>> GetChatByGroupName ([FromBody] ChatByGroupNameDto chatByGroupName )
        {
            var query = new GetChatByGroupNameQuery(chatByGroupName.groupName);

            var chats = await _mediator.Send(query); 

            return Ok(chats); 
        }
    }
}
