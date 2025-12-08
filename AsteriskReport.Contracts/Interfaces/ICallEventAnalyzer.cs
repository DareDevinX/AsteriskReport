using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Contracts.Interfaces
{
    public interface ICallEventAnalyzer
    {
        Call[] Analyze(QueueEvent[] queueEvent);
    }
}
