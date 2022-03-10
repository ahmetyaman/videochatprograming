using AutoMapper;
using Communicator.Application.Commands.PersonCreate;
using Communicator.Application.Responses;
using Communicator.Domain.Entities;

namespace Communicator.Application.Mapper
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonCreateCommand>().ReverseMap();

            CreateMap<Person, PersonResponse>().ReverseMap();
        }
    }
}