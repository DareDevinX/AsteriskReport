using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Contracts.Interfaces.Parsers
{
    public interface IEventTypeParser
    {
        public EventType Parse(string eventType);
    }
}
