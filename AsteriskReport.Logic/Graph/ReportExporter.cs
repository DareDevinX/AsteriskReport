using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Logic.Graph
{
    public class ReportExporter : IReportExporter
    {
        private readonly IBarGraphFactory barGraphFactory;

        public ReportExporter(IBarGraphFactory barGraphFactory)
        {
            this.barGraphFactory = barGraphFactory ?? throw new ArgumentNullException(nameof(barGraphFactory));
        }

        public void SaveReport(IEnumerable<Bar> bars)
        {
            var barGraph = this.barGraphFactory.Create(bars);
            barGraph.DrawBackground();
            barGraph.DrawAxis();

            foreach (var bar in bars)
            {
                barGraph.DrawBarLabel(bar.Timestamp, bar.X);
                foreach (var segment in bar.Segments)
                {
                    barGraph.DrawBarSegment(segment, bar.X);
                }
            }

            barGraph.SaveBitmap();
        }
    }
}
