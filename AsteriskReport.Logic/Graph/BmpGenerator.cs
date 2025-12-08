using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Logic.Graph
{
    public class BmpGenerator
    {
        private readonly IBarGraphFactory barGraphFactory;

        public BmpGenerator(IBarGraphFactory barGraphFactory)
        {
            this.barGraphFactory = barGraphFactory ?? throw new ArgumentNullException(nameof(barGraphFactory));
        }

        public void GenerateBmpImage(IEnumerable<Bar> bars)
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
