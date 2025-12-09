using AsteriskReport.Contracts.Interfaces;

namespace AsteriskReport.Logic
{
    public class TimestampParser : ITimestampParser
    {
        public DateTime FromUnix(string unixTimestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(long.Parse(unixTimestamp)).DateTime;
        }
    }
}
