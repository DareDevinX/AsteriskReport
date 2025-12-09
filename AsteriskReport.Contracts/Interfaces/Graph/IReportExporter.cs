using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Contracts.Interfaces.Graph
{
    public interface IReportExporter
    {
        void SaveReport(IEnumerable<Bar> bars);
    }
}