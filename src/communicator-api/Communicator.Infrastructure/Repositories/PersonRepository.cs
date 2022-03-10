using Communicator.Domain.Entities;
using Communicator.Domain.Repositories.Base;
using Communicator.Infrastructure.Data;
using Communicator.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Communicator.Infrastructure.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(CommunicatorContext dbContext) : base(dbContext)
        {
        }

        public async Task<Person> GetPersonByEmailandPassword(string email, string password)
        {
            return await _dbContext.Set<Person>().FirstOrDefaultAsync(x => string.Equals(x.Email, email) && string.Equals(x.Password, password));
        }

        public async Task<IEnumerable<Person>> GetPersonByName(string name)
        {
            return await this.GetAsync(p => p.Name == name);
        }
    }
}