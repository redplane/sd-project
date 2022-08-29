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
            _services = new ServiceCollection();
            _services.AddScoped<IBookService, BookService>();
            _services.AddScoped<IUserService, UserService>();

            _services.AddScoped<SdProjectDbContext>();

            _services.AddDbContext<SdProjectDbContext>(options =>
                options.UseInMemoryDatabase(Guid.NewGuid().ToString("D")));

            _services.AddScoped<SdProjectDbContext>();
        }

        [TearDown]
        public void TearDown()
        {
            _services.Clear();
        }
        
        private ServiceCollection _services;

        [Test]
        public async Task AddUserAsync_SendAddUserCommand_Returns_AddedUser()
        {
            var serviceProvider = _services.BuildServiceProvider();
            var userService = serviceProvider.GetRequiredService<IUserService>();
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