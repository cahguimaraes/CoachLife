namespace CoachLifeTests.Api.Controllers
{
    using AutoFixture.Idioms;
    using CoachLife.Api.Controllers;
    using CoachLife.Domain.Services.Interfaces;
    using CoachLifeTests.Fixtures.AutoData;
    using FluentResults;
    using NSubstitute;
    using System.Threading.Tasks;
    using Xunit;

    public class UserControllerTests
    {
        private UserController _testClass;
        private IUserService _userService;

        public UserControllerTests()
        {
            _userService = Substitute.For<IUserService>();
            _testClass = new UserController(_userService);
        }

        [Theory(DisplayName = "Deve garantir que o construtor valide suas dependÍncias"), AutoNSubstitute]
        public void ShouldGuardClause(GuardClauseAssertion guard)
        {
            guard.Verify(typeof(UserController).GetConstructors());
        }

        [Fact]
        public async Task CanCallGetUserAsync()
        {
            // Arrange
            var documentNumber = "123456";

            _userService.GetUserAsync(Arg.Any<string>()).Returns(Substitute.For<Result>());

            // Act
            var result = await _testClass.GetUserAsync(documentNumber);

            // Assert
            await _userService.Received().GetUserAsync(Arg.Any<string>());

            Assert.True(result.IsSuccess);
            //((OkObjectResult)result).StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}