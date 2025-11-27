using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Logic
{
    public class CallEventAnalyzer : ICallEventAnalyzer
    {
        private readonly ICallEventConverter[] callEventConverters;

        public CallEventAnalyzer(ICallEventConverter[] callEventConverters)
        {
            this.callEventConverters = callEventConverters ?? throw new ArgumentNullException(nameof(callEventConverters));
        }

        public Call[] Analyze(QueueEvent[] queueEvents)
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
