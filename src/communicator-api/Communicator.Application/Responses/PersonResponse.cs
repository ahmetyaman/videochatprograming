using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communicator.Application.Responses
{
   public class PersonResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public string PhotoUrl { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? LastActiveDate { get; set; }
    }
}
