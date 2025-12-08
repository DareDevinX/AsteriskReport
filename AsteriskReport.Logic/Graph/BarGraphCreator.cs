using AsteriskReport.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrapeCity.Documents.Imaging;
using GrapeCity.Documents.Svg;
using System.Net.Http.Headers;
using AsteriskReport.Contracts.Config;

namespace AsteriskReport.Logic.Graph
{
    public class BarGraphCreator
    {
        private readonly Config config;

        public BarGraphCreator(Config config)
        {
            this.config = config;
        }

        public IEnumerable<Bar> Create(Call[] calls)
        {
            var callsByTime = calls.GroupBy(c => c.StartTime).ToArray();
            var bars = new List<Bar>();
            for (var i = 0; i < callsByTime.Count(); i++)
            {
                var grouping = callsByTime[i];
                bars.Add(new Bar(convertCallGroupToBars(grouping), i));
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
                    Math.Min(call.WaitTimeSeconds, config.MaxBarSegmentLengthPixels));

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
