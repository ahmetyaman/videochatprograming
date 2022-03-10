using Communicator.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Communicator.Application.Queries
{
    public class GetAllPersonQuery : IRequest<IEnumerable<PersonResponse>>
    {
    }
}