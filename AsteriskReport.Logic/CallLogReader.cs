using AsteriskReport.Contracts.Config;
using AsteriskReport.Contracts.Interfaces;

namespace AsteriskReport.Logic
{
    public class CallLogReader : ICallLogReader
    {
        private readonly BarGraphConfig config;

        public CallLogReader(BarGraphConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public string[] ReadLogEntries()
        {
            return File.ReadAllLines(config.InputFilePath);
        }
    }
}
