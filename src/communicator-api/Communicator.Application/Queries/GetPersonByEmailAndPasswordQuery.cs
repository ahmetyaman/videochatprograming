using Communicator.Application.Responses;
using MediatR;

namespace Communicator.Application.Queries
{
    public class GetPersonByEmailAndPasswordQuery : IRequest<PersonResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public GetPersonByEmailAndPasswordQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}