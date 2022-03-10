using Communicator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator.Infrastructure.Data
{
    public class CommunicatorContextSeed
    {
        public static async Task SeedAsync(CommunicatorContext communicatorContext)
        {
            if (!communicatorContext.Persons.Any())
            {
                communicatorContext.Persons.AddRange(GetPreConfiguredPersons());

                await communicatorContext.SaveChangesAsync();
            }

            if (!communicatorContext.Chats.Any())
            {
                communicatorContext.Chats.AddRange(GetPreConfiguredChats());

                await communicatorContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Chat> GetPreConfiguredChats()
        {
            return new List<Chat>
            {
                new Chat()
                {
                    GroupId="1#||#2",
                    Message="Hello",
                    SendDate=DateTime.Now,
                    SenderId=1
                },
                 new Chat()
                {
                    GroupId="1#||#2",
                    Message="Hello",
                    SendDate=DateTime.Now,
                    SenderId=2
                },
                  new Chat()
                {
                    GroupId="1#||#2",
                    Message="How are you to day ?",
                    SendDate=DateTime.Now,
                    SenderId=1
                },
                   new Chat()
                {
                    GroupId="1#||#2",
                    Message="Realy Fine .",
                    SendDate=DateTime.Now,
                    SenderId=2
                },
                    new Chat()
                {
                    GroupId="1#||#2",
                    Message="You ?",
                    SendDate=DateTime.Now,
                    SenderId=2
                },

                     new Chat()
                {
                    GroupId="1#||#2",
                    Message="Absoulatly good",
                    SendDate=DateTime.Now,
                    SenderId=1
                },
                      new Chat()
                {
                    GroupId="1#||#2",
                    Message="Have you  ever been in İstanbul ?",
                    SendDate=DateTime.Now,
                    SenderId=1
                }
            };
        }

        private static IEnumerable<Person> GetPreConfiguredPersons()
        {
            return new List<Person> {
                 new Person()
                 {
                     Email="ahmetyamance@gmail.com",
                     Name="ahmet",
                     Password="123",
                     SurName="yaman",
                     PhotoUrl="https://bootdey.com/img/Content/avatar/avatar1.png",
                     IsActive =true,
                     LastActiveDate=null,
                 },

                   new Person()
                 {
                     Email="kubrayaman@gmail.com",
                     Name="kubra",
                     Password="123",
                     SurName="yaman",
                     PhotoUrl="https://bootdey.com/img/Content/avatar/avatar2.png",
                     IsActive =false,
                     LastActiveDate=DateTime.Now,
                 },

                     new Person()
                 {
                     Email="emineyaman@gmail.com",
                     Name="emine",
                     Password="123",
                     SurName="yaman",
                     PhotoUrl="https://bootdey.com/img/Content/avatar/avatar3.png",
                          IsActive =false,
                     LastActiveDate=DateTime.Now,
                 },

                          new Person()
                 {
                     Email="mehmetyaman@gmail.com",
                     Name="mehmet",
                     Password="123",
                     SurName="yaman",
                     PhotoUrl="https://bootdey.com/img/Content/avatar/avatar4.png",
                          IsActive =true,
                     LastActiveDate=null,
                 }
            };
        }
    }
}