using AutoMapper;
using Communicator.Application.Commands.PersonCreate;
using Communicator.Application.Responses;
using Communicator.Domain.Entities;
using Communicator.Domain.Repositories.Base;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Communicator.Application.Handlers
{
    public class PersonCreateHandler : IRequestHandler<PersonCreateCommand, PersonResponse>
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public PersonCreateHandler(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PersonResponse> Handle(PersonCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Person>(request);

            if (entity == null) throw new ApplicationException("Entity could not be mapped!");

            var resEntity = await _repository.AddAsync(entity);

            var response = _mapper.Map<PersonResponse>(resEntity);

            return response;
        }
    }
}