namespace AsteriskReport.Contracts.DTOs
{
    public class Call
    {
        public DateTime StartTime { get; set; }
        public bool WasSuccessful { get; set; }
        public int WaitTimeSeconds { get; set; }
        public int CallTimeSeconds { get; set; }
    }
}
