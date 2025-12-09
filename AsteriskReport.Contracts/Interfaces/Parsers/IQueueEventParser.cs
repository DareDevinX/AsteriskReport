using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Contracts.Interfaces.Parsers
{
    public interface IQueueEventParser
    {
        QueueEvent Parse(string queueLogEntry);
    }
}