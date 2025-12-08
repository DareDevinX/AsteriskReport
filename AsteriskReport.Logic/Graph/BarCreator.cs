using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Contracts.Config;

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
            for (var i = 0; i < callsByTime.Count(); i++)
            {
                var grouping = callsByTime[i];
                bars.Add(new Bar(convertCallGroupToBars(grouping), i, config.BarWidth, grouping.Key));
            }

            return bars;
        }

        private IEnumerable<BarSegment> convertCallGroupToBars(IEnumerable<Call> calls)
        {
            var barSegments = new List<BarSegment>();
            foreach (var call in calls)
            {
                var waitTimeSection = new BarSegment(
                    barSegments.Sum(segment => segment.Height),
                    Math.Max(config.MinBarSegmentLength, Math.Min(call.WaitTimeSeconds, config.MaxBarSegmentLength)));

                barSegments.Add(waitTimeSection);
                if (call.WasSuccessful)
                {
                    waitTimeSection.Color = BarColor.Yellow;
                    var callTimeSegment = new BarSegment(
                        barSegments.Sum(segment => segment.Height),
                        call.WaitTimeSeconds);
                    callTimeSegment.Color = BarColor.Green;
                    barSegments.Add(callTimeSegment);
                }
            }

            return barSegments;
        }
    }
}
