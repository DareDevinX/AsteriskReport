using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Logic.EventConverters
{
    public class SuccessfulCallEventConverter : ICallEventConverter
    {

        private EventType[] successfulCallEventTypes = new[]
        {
            EventType.CompleteCaller,
            EventType.CompleteAgent
        };

        public bool CanConvert(QueueEvent queueEvent)
        {
            return this.successfulCallEventTypes.Contains(queueEvent.EventType);
        }

        public Call Convert(QueueEvent queueEvent)
        {
            var callTimeSeconds = int.Parse(queueEvent.Parameters[1]);
            return new Call
            {
                StartTime = queueEvent.Timestamp.AddSeconds(-callTimeSeconds),
                WasSuccessful = true,
                CallTimeSeconds = callTimeSeconds,
                WaitTimeSeconds = int.Parse(queueEvent.Parameters[0])
            };
        }
    }
}
