using AsteriskReport.Contracts.Config;
using AsteriskReport.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Logic.Graph
{
    public class BmpGenerator
    {
        private readonly BarGraphConfig config;
        private Dictionary<BarColor, Brush> brushesByColor = new Dictionary<BarColor, Brush>()
        {
            { BarColor.Red, new SolidBrush(Color.Red)},
            { BarColor.Yellow, new SolidBrush(Color.Yellow)},
            { BarColor.Green, new SolidBrush(Color.Green)}
        };

        public BmpGenerator(BarGraphConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void GenerateBmpImage(IEnumerable<Bar> bars)
        {
            var canvasWidth = bars.Count() * (config.BarWidth + config.HorizontalSpacing);
            var canvasHeight = (int)bars.Max(bar => bar.Segments.Sum(segment => segment.Height));
            var bitmap = new Bitmap(canvasWidth, canvasHeight);
            var graphics = Graphics.FromImage(bitmap);


            var rects = new List<RectangleF>();
            foreach (var bar in bars)
            {
                foreach (var segment in bar.Segments)
                {
                    var rect = createRectFromSegment(segment, bar.X);
                    var brush = brushesByColor[segment.Color];
                    graphics.FillRectangle(brush, rect);
                }
            }

            bitmap.Save("output.bmp");
        }

        private RectangleF createRectFromSegment(BarSegment segment, float x)
        {
            return new RectangleF(
                x * (config.BarWidth + config.HorizontalSpacing),
                segment.Y,
                config.BarWidth,
                segment.Height);
        }
    }
}
