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
            var fileReader = new FileReader();
            var queueLogParser = new QueueEventParser(new TimestampConverter(), new EventTypeParser());
            var callEventConverters = new ICallEventConverter[]
            {
                new SuccessfulCallEventConverter(),
                new NoAnswerCallEventConverter(),
                new AbandonedCallEventConverter(),
            };

            var callEventAnalyzer = new CallEventAnalyzer(callEventConverters);
            var barGraphCreator = new BarGraphCreator();
            var svgGenerator = new SvgGenerator();

            // logic starts here
            var lines = fileReader.ReadLines("TestData\\Testdaten.txt");
            var queueEvents = lines.Select(queueLogParser.Parse).ToArray();
            var calls = callEventAnalyzer.Analyze(queueEvents);
            var bars = barGraphCreator.Create(calls);
            svgGenerator.GenerateSvgImage(bars);
        }
    }
}
