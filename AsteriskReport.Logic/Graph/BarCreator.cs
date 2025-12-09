using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Contracts.Config;
using AsteriskReport.Contracts.Interfaces.Graph;

namespace AsteriskReport.Logic.Graph
{
    public class BarCreator : IBarCreator
    {
        private readonly BarGraphConfig config;

        public BarCreator(BarGraphConfig config)
        {
            this.config = config;
        }

        public IEnumerable<Bar> Create(IEnumerable<Call> calls)
        {
            var callsByTime = calls.GroupBy(c => c.StartTime).ToArray();
            var bars = new List<Bar>();
            for (var i = 0; i < callsByTime.Length; i++)
            {
                var grouping = callsByTime[i];
                bars.Add(new Bar(this.convertCallGroupToBars(grouping), i, config.BarWidth, grouping.Key));
            }

            return bars;
        }

        private IEnumerable<BarSegment> convertCallGroupToBars(IEnumerable<Call> calls)
        {
            var barSegments = new List<BarSegment>();

            float calculateYPositionForNextSegment()
            {
                return barSegments.Sum(segment => segment.Height);
            }

            foreach (var call in calls)
            {
                var waitTimeSection = new BarSegment(
                    calculateYPositionForNextSegment(),
                    this.getTimeWithinBoundaries(call.WaitTimeSeconds));

                barSegments.Add(waitTimeSection);
                if (call.WasSuccessful)
                {
                    waitTimeSection.Color = BarColor.Yellow;
                    var callTimeSegment = new BarSegment(
                        calculateYPositionForNextSegment(),
                        this.getTimeWithinBoundaries(call.CallTimeSeconds));
                    callTimeSegment.Color = BarColor.Green;
                    barSegments.Add(callTimeSegment);
                }
            }

            return barSegments;
        }

        private int getTimeWithinBoundaries(int time)
        {
           return Math.Max(this.config.MinBarSegmentLength, Math.Min(time, this.config.MaxBarSegmentLength));
        }
    }
}
