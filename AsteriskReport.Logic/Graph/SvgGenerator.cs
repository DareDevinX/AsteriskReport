using AsteriskReport.Contracts.DTOs;
using GrapeCity.Documents.Imaging;
using GrapeCity.Documents.Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Logic.Graph
{
    public class SvgGenerator
    {
        private const int barWidth = 5;

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
            var canvasWidth = bars.Count() * barWidth;
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
            
            svgDoc.Save("output.svg");
        }

        private SvgRectElement createRectFromSegment(BarSegment segment, float x)
        {
            var section = new SvgRectElement();
            section.X = new SvgLength(x * barWidth);
            section.Y = new SvgLength(segment.Y);
            section.StrokeWidth = new SvgLength(1);
            section.MinWidth = new SvgLength(barWidth);
            section.MaxWidth = new SvgLength(barWidth);
            section.Width = new SvgLength(barWidth);
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