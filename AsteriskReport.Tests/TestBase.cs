using AutoFixture;
using ObjectsComparator.Comparator.Helpers;

namespace AsteriskReport.Tests
{
    public abstract class TestBase
    {
        protected IFixture Fixture = new Fixture();

        protected void AssertDeepEquality(object expected, object actual)
        {
            var comparisonResult = actual.DeeplyEquals(expected);
            Assert.IsTrue(comparisonResult.IsEmpty(), comparisonResult.FirstOrDefault()?.ToString());
        }
    }
}
