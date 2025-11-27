using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Logic
{
    public interface IQueueLogParser
    {
        QueueLog Parse(string queueLogEntry);
    }
}