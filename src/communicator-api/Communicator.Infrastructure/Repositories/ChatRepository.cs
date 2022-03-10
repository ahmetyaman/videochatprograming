using Communicator.Domain.Entities;
using Communicator.Domain.Repositories.Base;
using Communicator.Infrastructure.Data;
using Communicator.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator.Infrastructure.Repositories
{
    public class ChatRepository : Repository<Chat>, IChatRepository
    {
        public ChatRepository(CommunicatorContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Chat>> GetChatByGroupName(string name)
        {
            return await _dbContext.Set<Chat>().Where(x => string.Equals(x.GroupId, name)).ToListAsync();
        }
    }
}