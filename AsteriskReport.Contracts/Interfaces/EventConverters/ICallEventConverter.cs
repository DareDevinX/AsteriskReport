using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Contracts.Interfaces.EventConverters
{
    public interface ICallEventConverter
    {
        bool CanConvert(QueueEvent queueEvent);
        Call Convert(QueueEvent queueEvent);
    }
}
