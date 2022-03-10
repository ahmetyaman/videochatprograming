using Communicator.Domain.Entities.Base;
using System;

namespace Communicator.Domain.Entities
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string PhotoUrl { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? LastActiveDate { get; set; }
    }
}