using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Contracts.Interfaces;

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
                StartTime = queueEvent.Timestamp,
                WasSuccessful = false,
                WaitTimeSeconds = int.Parse(queueEvent.Parameters[0]),
                CallTimeSeconds = 0
            };
        }
    }
}
