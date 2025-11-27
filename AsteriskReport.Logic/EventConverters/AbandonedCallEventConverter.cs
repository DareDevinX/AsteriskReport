using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Logic.EventConverters
{
    public class AbandonedCallEventConverter : ICallEventConverter
    {
        public bool CanConvert(QueueEvent queueEvent)
        {
            return queueEvent.EventType == EventType.Abandon;
        }

        public Call Convert(QueueEvent queueEvent)
        {
            return new Call
            {
                StartTime = queueEvent.Timestamp,
                WasSuccessful = false,
                CallTimeSeconds = 0,
                WaitTimeSeconds = int.Parse(queueEvent.Parameters[2])
            };
        }
    }
}
