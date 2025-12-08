namespace AsteriskReport.Contracts.Interfaces
{
    public interface ITimestampConverter
    {
        public DateTime FromUnix(string unixTimestamp);
    }
}
