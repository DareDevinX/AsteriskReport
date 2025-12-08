using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Contracts.Interfaces
{
    public interface ICallEventConverter
    {
        bool CanConvert(QueueEvent queueEvent);
        Call Convert(QueueEvent queueEvent);
    }
}
