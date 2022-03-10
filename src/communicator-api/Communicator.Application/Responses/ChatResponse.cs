using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communicator.Application.Responses
{
 public   class ChatResponse
    {
        public int Id { get; set; }
        public string GroupId { get; set; }
        public int SenderId { get; set; }
        public string Message { get; set; }
        public DateTime? SendDate { get; set; }
    }
}
