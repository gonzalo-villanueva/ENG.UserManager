
using Xunit;
using Moq;
using ENG.UserManager.API.Controllers;
using ENG.UserManager.Domain.Interfaces.Services;
using ENG.UserManager.Domain.Models;
using Xunit.Sdk;

namespace ENG.UserManager.UnitTests
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _mockService;
        private readonly UserController _mockController;

        public UserControllerTests()
        {
            _mockService = new Mock<IUserService>();
            _mockController = new UserController(_mockService.Object);
        }

        [Fact]
        public async Task TestEndpoint()
        {
            // Act
            var result = _mockController.TestEndpoint();

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public async Task CreateUser()
        {
            // Arrange
            UserCreateModel mockUser = new() { UserName = "TEST", BirthDate = DateTime.Now };

            // Act
            var result = await _mockController.CreateUser(mockUser);

            Assert.NotNull(result.Value);

            // Assert
            //Assert.Equal(mockUser.UserName,result.Value?.UserName);
        }
    }
}