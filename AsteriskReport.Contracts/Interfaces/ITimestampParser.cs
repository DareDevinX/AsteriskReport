namespace AsteriskReport.Contracts.Interfaces
{
    public interface ITimestampParser
    {
        public DateTime FromUnix(string unixTimestamp);
    }
}
