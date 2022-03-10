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
    public class GetChatByGroupNameHandler : IRequestHandler<GetChatByGroupNameQuery, IEnumerable<ChatResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IChatRepository _repository;

        public GetChatByGroupNameHandler(IMapper mapper, IChatRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ChatResponse>> Handle(GetChatByGroupNameQuery request, CancellationToken cancellationToken)
        {
            var chats = await _repository.GetChatByGroupName(request.GroupName);

            var response = _mapper.Map<IEnumerable<ChatResponse>>(chats);
            return response;
        }
    }
}