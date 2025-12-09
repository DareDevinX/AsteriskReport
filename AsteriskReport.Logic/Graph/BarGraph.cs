using AsteriskReport.Contracts.Config;
using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Contracts.Interfaces.Graph;
using System.Drawing;
using System.Globalization;

namespace AsteriskReport.Logic.Graph
{
    public class BarGraph : IBarGraph
    {
        private readonly Bitmap bitmap;
        private readonly Graphics graphics;
        private readonly int barGraphHeight;
        private readonly int barGraphWidth;
        private readonly BarGraphConfig config;

        private static readonly Pen borderPen = new Pen(Color.Black, 1);
        private static readonly Brush backgroundBrush = new SolidBrush(Color.White);
        private static readonly Brush textBrush = new SolidBrush(Color.Black);
        private static readonly StringFormat verticalStringFormat = new StringFormat(StringFormatFlags.DirectionVertical);

        private readonly Dictionary<BarColor, Brush> brushesByColor = new Dictionary<BarColor, Brush>()
        {
            { BarColor.Red, new SolidBrush(Color.Red)},
            { BarColor.Yellow, new SolidBrush(Color.Yellow)},
            { BarColor.Green, new SolidBrush(Color.Green)}
        };

        public BarGraph(Bitmap bitmap, Graphics graphics, int barGraphHeight, int barGraphWidth, BarGraphConfig config)
        {
            this.bitmap = bitmap ?? throw new ArgumentNullException(nameof(bitmap));
            this.graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
            this.barGraphHeight = barGraphHeight;
            this.barGraphWidth = barGraphWidth;
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void DrawBackground()
        {
            graphics.FillRectangle(backgroundBrush, 0, 0, barGraphWidth + config.GraphLeftOffset, barGraphHeight + config.GraphBottomOffset);
        }

        public void DrawAxis()
        {
            graphics.DrawString(config.YAxisLabel, new Font(config.FontFamily, 10), textBrush, 30, 0, verticalStringFormat);
            graphics.DrawLine(borderPen, config.GraphLeftOffset, barGraphHeight, barGraphWidth + config.GraphLeftOffset, barGraphHeight);
            graphics.DrawLine(borderPen, config.GraphLeftOffset, barGraphHeight, config.GraphLeftOffset, 0);
        }

        public void DrawBarLabel(DateTime timestamp, float x)
        {
            var culture = CultureInfo.GetCultureInfo(config.TimestampCulture) ?? CultureInfo.InvariantCulture;
            var timestampString = timestamp.ToString(culture);
            graphics.DrawString(timestampString, new Font(config.FontFamily, 10), textBrush, calculateXPosition(x), barGraphHeight, verticalStringFormat);
        }

        public void DrawBarSegment(BarSegment segment, float x)
        {
            var rect = createRectFromSegment(segment, x, barGraphHeight);
            var brush = brushesByColor[segment.Color];
            graphics.FillRectangle(brush, rect);
            graphics.DrawRectangle(borderPen, rect);
        }

        private float calculateXPosition(float x)
        {
            return x * (config.BarWidth + config.HorizontalSpacing) + config.GraphLeftOffset;
        }

        private RectangleF createRectFromSegment(BarSegment segment, float horizontalPosition, float canvasHeight)
        {
            return new RectangleF(
                calculateXPosition(horizontalPosition),
                canvasHeight - segment.Height - segment.Y,
                config.BarWidth,
                segment.Height);
        }

        public void SaveBitmap()
        {
            this.bitmap.Save(config.OutputFileName);
        }
    }
}
