using Communicator.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communicator.Domain.Entities
{
   public class Chat : Entity
    {
        public string GroupId { get; set; }
        public int SenderId  { get; set; }
        public string Message { get; set; }
        public DateTime? SendDate { get; set; }

    }
}
