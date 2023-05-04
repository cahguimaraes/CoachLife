namespace CoachLifeTests.Api.Controllers
{
    using AutoFixture.Idioms;
    using CoachLife.Api.Controllers;
    using CoachLife.Domain.Services.Interfaces;
    using CoachLifeTests.Fixtures.AutoData;
    using Microsoft.AspNetCore.Mvc;
    using NSubstitute;
    using System;
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
            var userId = 1707220788;

            _userService.GetUserAsync(Arg.Any<int>()).Returns(Substitute.For<IActionResult>());

            // Act
            var result = await _testClass.GetUserAsync(userId);

            // Assert
            await _userService.Received().GetUserAsync(Arg.Any<int>());

            throw new NotImplementedException("Create or modify test");
        }
    }
}