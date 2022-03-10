using Communicator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communicator.Domain.Repositories.Base
{
  public  interface IChatRepository :IRepository<Chat>
    {

        Task<IEnumerable<Chat>> GetChatByGroupName(string name);
    }
}
