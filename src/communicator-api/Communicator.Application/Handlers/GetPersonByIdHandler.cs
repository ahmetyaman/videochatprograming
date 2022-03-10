using AutoMapper;
using Communicator.Application.Queries;
using Communicator.Application.Responses;
using Communicator.Domain.Repositories.Base;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Communicator.Application.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonResponse>
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public GetPersonByIdHandler(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PersonResponse> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var person = await _repository.GetByIdAsync(request.Id);
            var response = _mapper.Map<PersonResponse>(person);
            return response;
        }
    }
}