using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Logic.Graph
{
    public interface IBarCreator
    {
        IEnumerable<Bar> Create(Call[] calls);
    }
}