using Communicator.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communicator.Application.Queries
{
 public   class GetChatByGroupNameQuery:IRequest<IEnumerable<ChatResponse>>
    {
        public string GroupName { get; set; }

        public GetChatByGroupNameQuery(string groupName)
        {
            GroupName = groupName;
        }
    }
}
