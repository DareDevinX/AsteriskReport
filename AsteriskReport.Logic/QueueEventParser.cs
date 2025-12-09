using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Contracts.Interfaces;

namespace AsteriskReport.Logic
{
    public class QueueEventParser : IQueueEventParser
    {
        private readonly ITimestampParser timestampConverter;
        private readonly IEventTypeParser eventTypeParser;

        public QueueEventParser(ITimestampParser timestampConverter,
            IEventTypeParser eventTypeParser)
        {
            this.timestampConverter = timestampConverter ?? throw new ArgumentNullException(nameof(timestampConverter));
            this.eventTypeParser = eventTypeParser ?? throw new ArgumentNullException(nameof(eventTypeParser));
        }

        public QueueEvent Parse(string queueLogEntry)
        {
            var logEntryElements = queueLogEntry.Split('|');
            return new QueueEvent
            {
                Timestamp = timestampConverter.FromUnix(logEntryElements[0]),
                ChannelId = logEntryElements[1],
                QueueName = logEntryElements[2],
                QueueMemberChannel = logEntryElements[3],
                EventType = this.eventTypeParser.Parse(logEntryElements[4]),
                Parameters = logEntryElements.Skip(5).ToArray()
            };
        }
    }
}
