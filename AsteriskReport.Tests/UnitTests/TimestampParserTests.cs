using AsteriskReport.Logic.Parsers;
using AutoFixture;

namespace AsteriskReport.Tests.UnitTests
{
    [TestFixture]
    public class TimestampParserTests : TestBase
    {
        private TimestampParser sut;

        [SetUp]
        public void Setup()
        {
            this.sut = new TimestampParser();
        }

        [Test]
        public void Parse_WhenParsingUnixTimestamp_ShouldProvideCorrectDateTime()
        {
            // Arrange
            const string unixTimestamp = "1266833911";

            // Act
            var actualDateTime = this.sut.FromUnix(unixTimestamp);

            // Assert
            var expectedDateTime = new DateTime(2010, 2, 22, 10, 18, 31);
            AssertDeepEquality(expectedDateTime, actualDateTime);
        }

        [Test]
        public void Parse_WhenInputIsNotUnixTimestamp_ShouldThrowExeption()
        {
            // Arrange
            var notUnixTimestamp = Fixture.Create<string>();

            // Act, Assert
            Assert.Throws<FormatException>(() => this.sut.FromUnix(notUnixTimestamp));
        }
    }
}
