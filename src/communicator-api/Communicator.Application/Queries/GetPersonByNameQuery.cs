using Communicator.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Communicator.Application.Queries
{
    public class GetPersonByNameQuery : IRequest<IEnumerable<PersonResponse>>
    {
        public string Name { get; set; }

        public GetPersonByNameQuery(string name)
        {
            Name = name;
        }
    }
}