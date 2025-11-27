using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Logic.EventConverters
{
    public class NoAnswerCallEventConverter : ICallEventConverter
    {
        public bool CanConvert(QueueEvent queueEvent)
        {
            return queueEvent.EventType == EventType.RingNoAnswer;
        }

        public Call Convert(QueueEvent queueEvent)
        {
            return new Call
            {
                WasSuccessful = false,
                WaitTimeSeconds = int.Parse(queueEvent.Parameters[0]),
                CallTimeSeconds = 0
            };
        }
    }
}
