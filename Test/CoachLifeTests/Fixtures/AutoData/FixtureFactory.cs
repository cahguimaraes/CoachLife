using AutoFixture;
using Bogus;
using CoachLife.Domain.Models;
using CoachLife.Domain.Services.Interfaces;
using NSubstitute;

namespace CoachLifeTests.Fixtures.AutoData
{
    public class FixtureFactory
    {
        public static IFixture Create()
        {
            var faker = new Faker("pt_BR");

            var fixture = new Fixture()
                .Customize(new SubstituteCustomization());

            return fixture;
        }

        internal class SubstituteCustomization : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.Register(() => Substitute.For<User>());
                fixture.Register<IUserService>(() => null);
            }
        }
    }
}
