using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Logic;

namespace AsteriskReport.Tests.IntegrationTests
{
    [TestFixture]
    public class QueueLogParserTests
    {
        private QueueLogParser sut;

        [SetUp]
        public void Setup()
        {
            this.sut = new QueueLogParser(
                new TimestampConverter(),
                new EventTypeParser());
        }

        [Test]
        public void Parse_ShouldParseLine()
        {
            // Arrange
            var logEntry = "1266833911|1266833905.2|9000|Local/2001@from-internal/n|RINGNOANSWER|0";

            // Act
            var actualResult = this.sut.Parse(logEntry);

            // Assert
            var expectedResult = new QueueLog
            {
                Timestamp = new DateTime(2010, 2, 22, 10, 18, 31),
                ChannelId = "1266833905.2",
                QueueName = "9000",
                QueueMemberChannel = "Local/2001@from-internal/n",
                EventType = EventType.RingNoAnswer,
                Parameters = ["0"] 
            };
        }
    }
}