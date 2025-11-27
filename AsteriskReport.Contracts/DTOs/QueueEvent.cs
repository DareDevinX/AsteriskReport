using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Contracts.DTOs
{
    public class QueueEvent
    {
        public DateTime Timestamp { get; set; }
        public string ChannelId { get; set; }
        public string QueueName { get; set; }
        public string QueueMemberChannel { get; set; }
        public EventType EventType { get; set; }
        public string[] Parameters { get; set; }
    }
}
