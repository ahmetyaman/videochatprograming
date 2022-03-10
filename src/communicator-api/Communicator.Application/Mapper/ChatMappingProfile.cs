using AutoMapper;
using Communicator.Application.Responses;
using Communicator.Domain.Entities;

namespace Communicator.Application.Mapper
{
    public class ChatMappingProfile :Profile
    {
        public ChatMappingProfile()
        {
            //CreateMap<Chat, ChatCreateCommand>().ReverseMap();
            CreateMap<Chat, ChatResponse>().ReverseMap(); 
        }
    }
}