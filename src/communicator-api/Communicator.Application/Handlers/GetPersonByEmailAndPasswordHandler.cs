using AutoMapper;
using Communicator.Application.Queries;
using Communicator.Application.Responses;
using Communicator.Domain.Repositories.Base;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Communicator.Application.Handlers
{
    public class GetPersonByEmailAndPasswordHandler : IRequestHandler<GetPersonByEmailAndPasswordQuery, PersonResponse>
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public GetPersonByEmailAndPasswordHandler(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PersonResponse> Handle(GetPersonByEmailAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var person = await _repository.GetPersonByEmailandPassword(request.Email, request.Password);

            var response = _mapper.Map<PersonResponse>(person);
            return response;
        }
    }
}