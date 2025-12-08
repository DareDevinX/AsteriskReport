using AsteriskReport.Contracts.Interfaces;

namespace AsteriskReport.Logic
{
    public class TimestampConverter : ITimestampConverter
    {
        public DateTime FromUnix(string unixTimestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(long.Parse(unixTimestamp)).DateTime;
        }
    }
}
