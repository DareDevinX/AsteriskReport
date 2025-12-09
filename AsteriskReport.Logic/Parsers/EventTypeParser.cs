using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Contracts.Interfaces.Parsers;

namespace AsteriskReport.Logic.Parsers
{
    public class EventTypeParser : IEventTypeParser
    {
        private readonly Dictionary<string, EventType> eventTypesByUpperCaseName
            = Enum.GetValues<EventType>().ToDictionary(e => e.ToString().ToUpperInvariant());

        public EventType Parse(string eventType)
        {
            return eventTypesByUpperCaseName[eventType];
        }
    }
}
