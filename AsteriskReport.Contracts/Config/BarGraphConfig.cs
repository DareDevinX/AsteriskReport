namespace AsteriskReport.Contracts.Config
{
    public class BarGraphConfig
    {
        public int MaxBarSegmentLength { get; set; }
        public int BarWidth { get; set; }
        public int HorizontalSpacing { get; set; }
        public int MinBarSegmentLength { get; set; }
        public int GraphLeftOffset { get; set; }
        public int GraphBottomOffset { get; set; }
        public string FontFamily { get; set; }
        public string YAxisLabel { get; set; }
        public string TimestampCulture { get; set; }
        public string OutputFileName { get; set; }
        public string InputFilePath { get; set; }
    }
}
