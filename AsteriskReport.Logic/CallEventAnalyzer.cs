using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Contracts.Interfaces;

namespace AsteriskReport.Logic
{
    public class CallEventAnalyzer : ICallEventAnalyzer
    {
        private readonly IEnumerable<ICallEventConverter> callEventConverters;

        public CallEventAnalyzer(IEnumerable<ICallEventConverter> callEventConverters)
        {
            this.callEventConverters = callEventConverters ?? throw new ArgumentNullException(nameof(callEventConverters));
        }

        public IEnumerable<Call> Analyze(IEnumerable<QueueEvent> queueEvents)
        {
            var calls = new List<Call>();
            foreach (var queueEvent in queueEvents)
            {
                var converter = this.callEventConverters.SingleOrDefault(qe => qe.CanConvert(queueEvent));
                if (converter != null)
                {
                    calls.Add(converter.Convert(queueEvent));
                }
            }

            return calls.ToArray();
        }
    }
}
