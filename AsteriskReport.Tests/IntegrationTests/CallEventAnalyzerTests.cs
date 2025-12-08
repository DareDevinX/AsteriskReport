using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Contracts.Interfaces;
using AsteriskReport.Logic;
using AsteriskReport.Logic.EventConverters;
using AutoFixture;

namespace AsteriskReport.Tests.IntegrationTests
{
    [TestFixture]
    public class CallEventAnalyzerTests
    {
        private CallEventAnalyzer sut;
        private IFixture fixture;

        [SetUp]
        public void Setup()
        {
            this.fixture = new Fixture();
            var callEventConverters = new ICallEventConverter[]
            {
                new SuccessfulCallEventConverter(),
                new NoAnswerCallEventConverter(),
                new AbandonedCallEventConverter(),
            };

            this.sut = new CallEventAnalyzer(callEventConverters);
        }

        [Test]
        public void Analyze_WhenProvidedWithEvent_IfEventIsCall_ShouldConvertEvent()
        {
            // Arrange
            var queueEvents = this.createTestData();

            // Act
            var actualCalls = this.sut.Analyze(queueEvents);

            // Assert
            Assert.That(actualCalls.Count, Is.EqualTo(4));
        }
            
        private QueueEvent[] createTestData()
        {
            return
            [
                createEvent(EventType.Abandon, 3),
                createEvent(EventType.RingNoAnswer, 1),
                createEvent(EventType.CompleteAgent, 3),
                createEvent(EventType.CompleteCaller, 3),
                createEvent(EventType.Connect, 3),
                createEvent(EventType.EnterQueue, 3),
                createEvent(EventType.ConfigReload, 3),
            ];
        }

        private QueueEvent createEvent(EventType eventType, int parameterCount)
        {
            var parameters = this.fixture.CreateMany<int>(parameterCount).Select(i => i.ToString()).ToArray();
            return this.fixture.Build<QueueEvent>()
                .With(e => e.EventType, eventType)
                .With(e => e.Parameters, parameters)
                .Create();
        }
    }
}
