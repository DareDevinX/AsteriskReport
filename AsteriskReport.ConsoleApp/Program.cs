using AsteriskReport.Logic;

namespace AsteriskReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader();
            var lines = fileReader.ReadLines("TestData\\Testdaten.txt");
            var queueLogParser = new QueueEventParser(new TimestampConverter(), new EventTypeParser());
            var queueLogs = lines.Select(queueLogParser.Parse);
        }
    }
}
