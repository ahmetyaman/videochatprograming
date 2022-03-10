using AutoMapper;
using Communicator.Application.Queries;
using Communicator.Application.Responses;
using Communicator.Domain.Repositories.Base;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Communicator.Application.Handlers
{
    public class GetAllPersonHandler : IRequestHandler<GetAllPersonQuery, IEnumerable<PersonResponse>>
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPersonHandler(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonResponse>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            var personList = await _repository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<PersonResponse>>(personList);
            return response;
        }
    }
}