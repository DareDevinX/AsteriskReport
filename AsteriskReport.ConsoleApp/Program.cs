using AsteriskReport.Contracts.Config;
using AsteriskReport.Contracts.Interfaces;
using AsteriskReport.Logic;
using AsteriskReport.Logic.EventConverters;
using AsteriskReport.Logic.Graph;

namespace AsteriskReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DI starts here
            var config = new BarGraphConfig()
            {
                MaxBarSegmentLength = 100,
                BarWidth = 20,
                HorizontalSpacing = 5,
                MinBarSegmentLength = 2,
                GraphLeftOffset = 50,
                GraphBottomOffset = 150

            };
            var fileReader = new FileReader();
            var queueLogParser = new QueueEventParser(new TimestampConverter(), new EventTypeParser());
            var callEventConverters = new ICallEventConverter[]
            {
                new SuccessfulCallEventConverter(),
                new NoAnswerCallEventConverter(),
                new AbandonedCallEventConverter(),
            };

            var callEventAnalyzer = new CallEventAnalyzer(callEventConverters);
            var barGraphCreator = new BarGraphCreator(config);
            var bitmapGenerator = new BmpGenerator(config);

            // logic starts here
            var lines = fileReader.ReadLines("TestData\\Testdaten.txt");
            var queueEvents = lines.Select(queueLogParser.Parse).ToArray();
            var calls = callEventAnalyzer.Analyze(queueEvents);
            var bars = barGraphCreator.Create(calls);
            bitmapGenerator.GenerateBmpImage(bars);
        }
    }
}
