using AutoFixture;
using AutoFixture.Xunit2;

namespace CoachLifeTests.Fixtures.AutoData
{
    public class AutoNSubstituteAttribute : AutoDataAttribute
    {
        public AutoNSubstituteAttribute() : this(FixtureFactory.Create) { }
        public AutoNSubstituteAttribute(Func<IFixture> fixtureFactory) : base(fixtureFactory) { }
    }
}
