using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Contracts.DTOs
{
    public enum EventType
    {
        QueueStart,
        ConfigureLoad,
        RingNoAnswer,
        Connect,
        CompleteAgent,
        CompleteCaller,
        EnterQueue,
        Abandon
    }
}
