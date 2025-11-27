using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Logic
{
    public class QueueLogParser : IQueueLogParser
    {
        private readonly ITimestampConverter timestampConverter;
        private readonly IEventTypeParser eventTypeParser;

        public QueueLogParser(ITimestampConverter timestampConverter,
            IEventTypeParser eventTypeParser)
        {
            this.timestampConverter = timestampConverter ?? throw new ArgumentNullException(nameof(timestampConverter));
            this.eventTypeParser = eventTypeParser ?? throw new ArgumentNullException(nameof(eventTypeParser));
        }

        public QueueLog Parse(string queueLogEntry)
        {
            var logEntryElements = queueLogEntry.Split('|');
            return new QueueLog
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
