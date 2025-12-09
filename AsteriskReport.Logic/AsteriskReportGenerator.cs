using AsteriskReport.Contracts.Interfaces;
using AsteriskReport.Logic.Graph;

namespace AsteriskReport.Logic
{
    public class AsteriskReportGenerator
    {
        private readonly ICallLogReader callLogReader;
        private readonly IQueueEventParser queueEventParser;
        private readonly ICallEventAnalyzer callEventAnalyzer;
        private readonly IBarCreator barCreator;
        private readonly IReportExporter reportExporter;

        public AsteriskReportGenerator(ICallLogReader fileReader,
            IQueueEventParser queueEventParser,
            ICallEventAnalyzer callEventAnalyzer, 
            IBarCreator barCreator,
            IReportExporter reportExporter)
        {
            this.callLogReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
            this.queueEventParser = queueEventParser ?? throw new ArgumentNullException(nameof(queueEventParser));
            this.callEventAnalyzer = callEventAnalyzer ?? throw new ArgumentNullException(nameof(callEventAnalyzer));
            this.barCreator = barCreator ?? throw new ArgumentNullException(nameof(barCreator));
            this.reportExporter = reportExporter ?? throw new ArgumentNullException(nameof(reportExporter));
        }

        public void Generate()
        {
            var entries = callLogReader.ReadLogEntries();
            var queueEvents = entries.Select(queueEventParser.Parse).ToArray();
            var calls = callEventAnalyzer.Analyze(queueEvents);
            var bars = barCreator.Create(calls);
            reportExporter.SaveReport(bars);
        }
    }
}
