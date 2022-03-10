using Communicator.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Communicator.Domain.Repositories.Base
{
    public  interface IPersonRepository : IRepository<Person>
    {
        Task<IEnumerable<Person>> GetPersonByName(string name );

        Task<Person> GetPersonByEmailandPassword(string email, string password);

    }
}