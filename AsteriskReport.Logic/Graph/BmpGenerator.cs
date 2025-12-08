using AsteriskReport.Contracts.Config;
using AsteriskReport.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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

        private Pen borderPen = new Pen(Color.Black, 1);
        private Brush backgroundBrush = new SolidBrush(Color.White);
        private Brush textBrush = new SolidBrush(Color.Black);

        public BmpGenerator(BarGraphConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void GenerateBmpImage(IEnumerable<Bar> bars)
        {
            var canvasWidth = bars.Count() * (config.BarWidth + config.HorizontalSpacing);
            var canvasHeight = (int)bars.Max(bar => bar.Segments.Sum(segment => segment.Height));
            var bitmap = new Bitmap(canvasWidth + config.GraphLeftOffset, canvasHeight + config.GraphBottomOffset);
            var graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(backgroundBrush, 0, 0, canvasWidth + config.GraphLeftOffset, canvasHeight + config.GraphBottomOffset);

            var stringFormat = new StringFormat(StringFormatFlags.DirectionVertical);
            graphics.DrawString("Calls", new Font("Arial", 10), textBrush, 30, 0, stringFormat);
            graphics.DrawLine(borderPen, config.GraphLeftOffset, canvasHeight, canvasWidth + config.GraphLeftOffset, canvasHeight);
            graphics.DrawLine(borderPen, config.GraphLeftOffset, canvasHeight, config.GraphLeftOffset, 0);


            var rects = new List<RectangleF>();
            foreach (var bar in bars)
            {
                var timestampString = bar.Timestamp.ToString(CultureInfo.InvariantCulture);
                graphics.DrawString(timestampString, new Font("Arial", 10), textBrush, calculateXPosition(bar.X), canvasHeight, stringFormat);
                foreach (var segment in bar.Segments)
                {
                    var rect = createRectFromSegment(segment, bar.X, canvasHeight);
                    var brush = brushesByColor[segment.Color];
                    graphics.FillRectangle(brush, rect);
                    graphics.DrawRectangle(borderPen, rect);
                    
                }
            }

            bitmap.Save("output.bmp");
        }

        private RectangleF createRectFromSegment(BarSegment segment, float x, float canvasHeight)
        {
            return new RectangleF(
                calculateXPosition(x),
                canvasHeight - segment.Height - segment.Y,
                config.BarWidth,
                segment.Height);
        }

        private float calculateXPosition(float x)
        {
            return x * (config.BarWidth + config.HorizontalSpacing) + config.GraphLeftOffset;
        }
    }
}
