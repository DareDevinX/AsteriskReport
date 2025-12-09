using AsteriskReport.Contracts.Interfaces.Parsers;

namespace AsteriskReport.Logic.Parsers
{
    public class TimestampParser : ITimestampParser
    {
        public DateTime FromUnix(string unixTimestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(long.Parse(unixTimestamp)).DateTime;
        }
    }
}
