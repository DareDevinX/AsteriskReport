using AsteriskReport.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrapeCity.Documents.Imaging;
using GrapeCity.Documents.Svg;
using System.Net.Http.Headers;

namespace AsteriskReport.Logic
{
    public class BarGraphCreator
    {
        private const int barWidth = 5;

        public void Create(Call[] calls)
        {
            var callsByTime = calls.GroupBy(c => c.StartTime).ToArray();
            var bars = new List<Bar>();
            for (var i = 0; i < callsByTime.Count(); i++)
            {
                var grouping = callsByTime[i];
                bars.Add(new Bar(convertCallGroupToBars(grouping), i));
            }

            var rects = new List<SvgRectElement>();
            foreach (var bar in bars)
            {
                foreach (var segment in bar.Segments)
                {
                    rects.Add(createRectFromSegment(segment, bar.X));
                }
            }
            
        }

        private IEnumerable<BarSegment> convertCallGroupToBars(IEnumerable<Call> calls)
        {
            var barSegments = new List<BarSegment>();
            foreach (var call in calls)
            {
                var waitTimeSection = new BarSegment( 
                    barSegments.Sum(segment => segment.Height), 
                    call.WaitTimeSeconds);

                barSegments.Add(waitTimeSection);
                if (call.WasSuccessful)
                {
                    waitTimeSection.Color = Color.Yellow;
                    // add call time in green
                    var callTimeSegment = new BarSegment(
                        barSegments.Sum(segment => segment.Height),
                        call.WaitTimeSeconds);
                    callTimeSegment.Color = Color.Green;
                    barSegments.Add(callTimeSegment);
                }
            }

            return barSegments;
        }

        private SvgRectElement createRectFromSegment(BarSegment segment, float x)
        {
            var section = new SvgRectElement();
            section.X = new SvgLength(x);
            section.Y = new SvgLength(segment.Y);
            section.StrokeWidth = new SvgLength(1);
            section.MinWidth = new SvgLength(barWidth);
            section.MinHeight = new SvgLength(segment.Height);
            section.Color = new SvgColor((int)segment.Color);
            return section;
        }
    }
}
