using FakeItEasy;
using Xunit;
using Store.DataContext.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Linq;
using Store.DataContext.Context;

namespace Store.WebAPI.Services.Tests
{
    public class IdentityServiceTests
    {
        [Fact]
        public void GetIdentity_ValidUser_ReturnsClaimsIdentity()
        {
            // Arrange
            var fakeDbContext = A.Fake<IStoreDbContext>();

            var realPasswordHasher = new PasswordHasher<User>();

            var testUser = new User
            {
                Login = "testUser",
                Hash = realPasswordHasher.HashPassword(new User(), "userPassword"),
                Role = 0
            };

            A.CallTo(() => fakeDbContext.GetUserByUsername(testUser.Login)).Returns(testUser);
            var identityService = new IdentityService(fakeDbContext, realPasswordHasher);

            // Act
            var identity = identityService.GetIdentity(testUser.Login, "userPassword");

            // Assert
            Assert.NotNull(identity);
            Assert.Equal(testUser.Login, identity.Name);
            Assert.Contains(identity.Claims, c => c.Type == ClaimTypes.Name && c.Value == testUser.Login);
            Assert.Contains(identity.Claims, c => c.Type == ClaimTypes.Role && c.Value == "USER");
        }

        [Fact]
        public void GetIdentity_ValidAdmin_ReturnsClaimsIdentity()
        {
            // Arrange
            var fakeDbContext = A.Fake<IStoreDbContext>();

            var realPasswordHasher = new PasswordHasher<User>();

            var testUser = new User
            {
                Login = "testUser",
                Hash = realPasswordHasher.HashPassword(new User(), "adminPassword"),
                Role = 1
            };

            A.CallTo(() => fakeDbContext.GetUserByUsername(testUser.Login)).Returns(testUser);
            var identityService = new IdentityService(fakeDbContext, realPasswordHasher);

            // Act
            var identity = identityService.GetIdentity(testUser.Login, "adminPassword");

            // Assert
            Assert.NotNull(identity);
            Assert.Equal(testUser.Login, identity.Name);
            Assert.Contains(identity.Claims, c => c.Type == ClaimTypes.Name && c.Value == testUser.Login);
            Assert.Contains(identity.Claims, c => c.Type == ClaimTypes.Role && c.Value == "USER");
            Assert.Contains(identity.Claims, c => c.Type == ClaimTypes.Role && c.Value == "ADMIN");
        }

        [Fact]
        public void GetIdentity_InvalidUser_ReturnsNull()
        {
            // Arrange
            var fakeDbContext = A.Fake<IStoreDbContext>();
            var realPasswordHasher = new PasswordHasher<User>();

            var testUser = new User
            {
                Login = "testUser",
                Hash = realPasswordHasher.HashPassword(new User(), "userPassword"),
                Role = 0
            };

            A.CallTo(() => fakeDbContext.GetUserByUsername(testUser.Login)).Returns(testUser);
            var identityService = new IdentityService(fakeDbContext, realPasswordHasher);

            // Act
            var identity = identityService.GetIdentity("invalidUser", "wrongPassword");

            // Assert
            Assert.Null(identity);
        }
    }
}
