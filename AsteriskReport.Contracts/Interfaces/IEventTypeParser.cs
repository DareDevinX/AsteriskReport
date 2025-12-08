using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Contracts.Interfaces
{
    public interface IEventTypeParser
    {
        public EventType Parse(string eventType);
    }
}
