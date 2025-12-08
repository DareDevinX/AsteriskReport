using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Contracts.Interfaces
{
    public interface ICallEventAnalyzer
    {
        IEnumerable<Call> Analyze(IEnumerable<QueueEvent> queueEvent);
    }
}
