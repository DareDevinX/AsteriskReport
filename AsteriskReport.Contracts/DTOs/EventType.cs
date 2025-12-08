namespace AsteriskReport.Contracts.DTOs
{
    public enum EventType
    {
        QueueStart,
        ConfigReload,
        RingNoAnswer,
        Connect,
        CompleteAgent,
        CompleteCaller,
        EnterQueue,
        Abandon
    }
}
