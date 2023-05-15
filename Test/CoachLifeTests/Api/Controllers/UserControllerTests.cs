namespace CoachLifeTests.Api.Controllers
{
    using AutoFixture;
    using AutoFixture.AutoNSubstitute;
    using AutoFixture.Idioms;
    using CoachLife.Api.Controllers;
    using CoachLife.Domain.Models;
    using CoachLife.Domain.Services.Interfaces;
    using CoachLifeTests.Fixtures.AutoData;
    using FluentAssertions;
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;
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

        [Theory(DisplayName = "Deve garantir que o construtor valide suas dependências"), AutoNSubstitute]
        public void ShouldGuardClause(GuardClauseAssertion guard)
        {
            guard.Verify(typeof(UserController).GetConstructors());
        }

        [Fact]
        public async Task CanCallGetUserAsync()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            var documentNumber = fixture.Create<string>();

            _userService.GetUserAsync(Arg.Any<string>())
                .Returns(fixture.Create<Result<User>>());

            // Act
            var result = await _testClass.GetUserAsync(documentNumber);

            // Assert
            await _userService.Received().GetUserAsync(Arg.Any<string>());
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task CannotCallGetUserAsyncReturnNotFound()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            var documentNumber = fixture.Create<string>();
            var error = Result.Fail<User>("User not found");

            _userService.GetUserAsync(Arg.Any<string>())
                .Returns(error);

            // Act
            var result = await _testClass.GetUserAsync(documentNumber);

            // Assert
            await _userService.Received().GetUserAsync(Arg.Any<string>());
            result.Should().BeOfType<ObjectResult>();
        }
    }
}