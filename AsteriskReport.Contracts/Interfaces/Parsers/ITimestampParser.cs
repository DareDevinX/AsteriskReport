namespace AsteriskReport.Contracts.Interfaces.Parsers
{
    public interface ITimestampParser
    {
        public DateTime FromUnix(string unixTimestamp);
    }
}
