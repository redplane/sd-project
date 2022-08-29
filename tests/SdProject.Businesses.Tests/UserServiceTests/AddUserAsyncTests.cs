using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SdProject.Businesses.Cqrs.Commands.Users;
using SdProject.Businesses.Services;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.DbContexts;

namespace SdProject.Businesses.Tests.UserServiceTests
{
    [TestFixture]
    public class AddUserAsyncTests
    {
        [SetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<SdProjectDbContext>();

            services.AddDbContext<SdProjectDbContext>(options =>
                options.UseInMemoryDatabase("SdProjectDB"));

            services.AddScoped<SdProjectDbContext>();
            _serviceProvider = services.BuildServiceProvider();
        }

        private IServiceProvider _serviceProvider;

        [Test]
        public async Task AddUserAsync_SendAddUserCommand_Returns_AddedUser()
        {
            var userService = _serviceProvider.GetRequiredService<IUserService>();
            var addUserCommand = new AddUserCommand
                { FirstName = "Liam-2909-1", LastName = "Nguyen", Birthdate = DateTime.Now };
            var addedUser = await userService.AddAsync(addUserCommand, default);
            
            Assert.NotNull(addedUser);
            Assert.AreEqual(addedUser.FirstName, addUserCommand.FirstName);
            Assert.AreEqual(addedUser.LastName, addUserCommand.LastName);
            Assert.AreEqual(addedUser.Birthdate, addUserCommand.Birthdate);
        }
    }
}