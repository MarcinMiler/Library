using System;
using Xunit;
using Moq;
using AutoMapper;
using Library.Core.Respository;
using Library.Infrastructure.Services;
using System.Threading.Tasks;
using Library.Core.Domain;
using FluentAssertions;

namespace Library.Tests
{
    public class UserServiceTest
    {
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
        public async Task should_login_with_correct_credentials()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            var user = new User("m@m.com", "mm", "mmmmm", "marcinek");
            userRepositoryMock.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(() => user);

            await userService.Login("m@m.com", "mm");
        }

        [Fact]
        public async Task should_not_login_with_uncorrect_credentials()
        {
            //assert
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            var user = new User("m@m.com", "mm", "mmmmm", "marcinek");
            userRepositoryMock.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(() => user);

            // act
            var task = Task.Run(async () => await userService.Login("a@a.com", "mmmmmmm"));
            var ex = Record.ExceptionAsync(async () => await task);

            ex.Should().NotBeNull();
            ex.Result.Message.Should().Be("Invalid Credentials.");
        }
    }
}
