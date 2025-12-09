using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Contracts.Interfaces.Graph
{
    public interface IBarGraphFactory
    {
        IBarGraph Create(IEnumerable<Bar> bars);
    }
}