using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Contracts.Interfaces.Graph
{
    public interface IBarCreator
    {
        IEnumerable<Bar> Create(IEnumerable<Call> calls);
    }
}