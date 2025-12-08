using AsteriskReport.Contracts.Config;
using AsteriskReport.Contracts.DTOs;
using GrapeCity.Documents.Svg;
using System.Drawing;

namespace AsteriskReport.Logic.Graph
{
    public class SvgGenerator
    {
        private readonly BarGraphConfig config;

        public SvgGenerator(BarGraphConfig config)
        {
            this.config = config;
        }

        public void GenerateSvgImage(IEnumerable<Bar> bars)
        {
            var rects = new List<SvgRectElement>();
            foreach (var bar in bars)
            {
                foreach (var segment in bar.Segments)
                {
                    rects.Add(createRectFromSegment(segment, bar.X));
                }
            }

            var svgDoc = new GcSvgDocument();
            var canvasWidth = bars.Count() * (config.BarWidth + config.HorizontalSpacing);
            svgDoc.RootSvg.Width = new SvgLength(canvasWidth);
            var canvasHeight = bars.Max(bar => bar.Segments.Sum(segment => segment.Height));
            svgDoc.RootSvg.Height = new SvgLength(canvasHeight);
            svgDoc.RootSvg.Children.AddRange(rects);
            var viewBox = new SvgViewBox();
            viewBox.MinX = 0;
            viewBox.MinY = 0;
            viewBox.Width = canvasWidth;
            viewBox.Height = canvasHeight;
            svgDoc.RootSvg.ViewBox = viewBox;
            svgDoc.RootSvg.Transform =
            [
                new SvgScaleTransform
                {
                    ScaleX = 1,
                    ScaleY = -1
                }
            ];

            svgDoc.Save("output.svg");
        }

        private SvgRectElement createRectFromSegment(BarSegment segment, float x)
        {
            var section = new SvgRectElement();
            section.X = new SvgLength(x * (config.BarWidth + config.HorizontalSpacing));
            section.Y = new SvgLength(segment.Y);
            section.StrokeWidth = new SvgLength(1);
            section.MinWidth = new SvgLength(config.BarWidth);
            section.MaxWidth = new SvgLength(config.BarWidth);
            section.Width = new SvgLength(config.BarWidth);
            section.Height = new SvgLength(segment.Height);
            section.MinHeight = new SvgLength(segment.Height);
            section.MaxHeight = new SvgLength(segment.Height);
            section.Fill = getColor(segment.Color);
            section.Stroke = new SvgPaint(Color.Black);
            return section;
        }

        private SvgPaint getColor(BarColor barColor)
        {
            switch (barColor)
            {
                case BarColor.Red:
                    return new SvgPaint(Color.Red);
                case BarColor.Yellow:
                    return new SvgPaint(Color.Yellow);
                case BarColor.Green:
                    return new SvgPaint(Color.Green);
                default:
                    throw new ArgumentOutOfRangeException("Invalid color for bar graph");
            }
        }
    }
}