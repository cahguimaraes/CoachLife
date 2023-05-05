using AutoFixture.Xunit2;
using Xunit;

namespace CoachLifeTests.Fixtures.AutoData
{
    public class AutoInlineDataAttribute : CompositeDataAttribute
    {
        public AutoInlineDataAttribute(params object[] values)
           : base(new InlineDataAttribute(values), new AutoNSubstituteAttribute())
        {
        }
    }
}
