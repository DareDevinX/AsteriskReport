using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Logic.Graph
{
    public interface IReportExporter
    {
        void SaveReport(IEnumerable<Bar> bars);
    }
}