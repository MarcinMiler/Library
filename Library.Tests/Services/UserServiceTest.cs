using System;
using Xunit;
using Moq;
using AutoMapper;
using Library.Core.Respository;
using Library.Infrastructure.Services;
using System.Threading.Tasks;
using Library.Core.Domain;

namespace Library.Tests
{
    public class UserServiceTest
    {
        [Fact]
        public async Task should_register_user()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            await userService.Register("user@email.com", "password", "Username");

            userRepositoryMock.Verify(x => x.Add(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task should_return_user_from_given_email()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            await userService.Get("m@m.com");

            var user = new User("m@m.com", "mm", "mmmmm", "marcinek");

            userRepositoryMock.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(() => user);

            userRepositoryMock.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
        }
    }
}
