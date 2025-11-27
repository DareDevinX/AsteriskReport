using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Logic
{
    public interface IQueueEventParser
    {
        QueueEvent Parse(string queueLogEntry);
    }
}