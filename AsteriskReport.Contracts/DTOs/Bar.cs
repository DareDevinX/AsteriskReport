namespace AsteriskReport.Contracts.DTOs
{
    public class Bar
    {
        public float HorizontalPosition { get; set; }
        public IEnumerable<BarSegment> Segments { get; set; }
        public float Width { get; set; }

        public DateTime Timestamp { get; set; }

        public Bar(IEnumerable<BarSegment> segments, float horizontalPosition, float width, DateTime timestamp)
        {
            this.Segments = segments;
            this.HorizontalPosition = horizontalPosition;
            this.Width = width;
            this.Timestamp = timestamp;
        }
    }
}
