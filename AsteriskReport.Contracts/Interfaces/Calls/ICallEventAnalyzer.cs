using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Contracts.Interfaces.Calls
{
    public interface ICallEventAnalyzer
    {
        IEnumerable<Call> Analyze(IEnumerable<QueueEvent> queueEvent);
    }
}
