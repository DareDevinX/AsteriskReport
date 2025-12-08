using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Logic.Graph
{
    public interface IBarGraphFactory
    {
        IBarGraph Create(IEnumerable<Bar> bars);
    }
}