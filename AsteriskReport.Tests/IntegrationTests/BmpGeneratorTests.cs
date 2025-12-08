using AsteriskReport.Contracts.Config;
using AsteriskReport.Contracts.DTOs;
using AsteriskReport.Logic.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Tests.IntegrationTests
{
    [TestFixture]
    public class BmpGeneratorTests
    {
        private BmpGenerator sut;

        [SetUp]
        public void Setup()
        {
            var config = new BarGraphConfig()
            {
                MaxBarSegmentLength = 100,
                BarWidth = 10,
                HorizontalSpacing = 5,
                MinBarSegmentLength = 2

            };
            this.sut = new BmpGenerator(config);
        }

        [Test]
        public void GenerateBmpImage_ShouldGenerateImage()
        {
            // Arrange
            var segments = new BarSegment[]
            {
                new BarSegment(0, 10, BarColor.Red),
                new BarSegment(10, 10, BarColor.Yellow),
                new BarSegment(20, 10, BarColor.Green),
            };
            var bar = new Bar(segments, 0, 10);

            // Act
            this.sut.GenerateBmpImage(new[] { bar });
        }
    }
}
