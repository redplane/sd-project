using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SdProject.Businesses.Models.Users;
using SdProject.Businesses.Services;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.DbContexts;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SdProject.Businesses.Tests.UserServiceTests
{
    [TestFixture]
    public class AddUserAsyncTests
    {
        private IServiceProvider _serviceProvider;
        private int userId;
        private int bookId;
        private int userBookId;

        [SetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<SdPDbContext>();

            services.AddDbContext<SdPDbContext>(options =>
    options.UseInMemoryDatabase(databaseName: "SdProjectDB"));

            services.AddScoped<SdPDbContext>();
            _serviceProvider = services.BuildServiceProvider();
        }

        [Test]
        public async Task AddUserAsync_SendAddUserCommand_Returns_AddedUser()
        {
            var userService = _serviceProvider.GetRequiredService<IUserService>();
            var addUserCommand = new AddUserCommand() { FirstName = "Liam-2909-1", LastName = "Nguyen", Birthdate = DateTime.Now };
            var result = await userService.AddUserAsync(addUserCommand, default);
            userId = result.id;

            Assert.NotNull(result, "Add user failed");
            Assert.AreEqual(result.FirstName, addUserCommand.FirstName);
            Assert.AreEqual(result.LastName, addUserCommand.LastName);
            Assert.AreEqual(result.Birthdate, addUserCommand.Birthdate);
        }

        [Test]
        public async Task UpdateUserAsync_SendUpdateUserCommand_Returns_UpdatedUser()
        {
            var userService = _serviceProvider.GetRequiredService<IUserService>();
            var updateUserCommand = new UpdateUserCommand() { Id = userId, FirstName = "Liam-2909-2", LastName = "Nguyen", Birthdate = DateTime.Now };
            var result = await userService.UpdateUserAsync(updateUserCommand, default);

            Assert.NotNull(result, "Update user failed");
            Assert.AreEqual(result.id, updateUserCommand.Id);
            Assert.AreEqual(result.FirstName, updateUserCommand.FirstName);
            Assert.AreEqual(result.LastName, updateUserCommand.LastName);
            Assert.AreEqual(result.Birthdate, updateUserCommand.Birthdate);
        }

        [Test]
        public async Task AddBookAsync_SendAddBookCommand_Returns_AddedBook()
        {
            var bookService = _serviceProvider.GetRequiredService<IBookService>();
            var addBookCommand = new AddBookCommand() { Title = "Book-2808-1", Category = "Category", Description = "Description", Price = 155000 };
            var result = await bookService.AddBookAsync(addBookCommand, default);
            bookId = result.Id;

            Assert.NotNull(result, "Add book failed");
            Assert.AreEqual(result.Title, addBookCommand.Title);
            Assert.AreEqual(result.Category, addBookCommand.Category);
            Assert.AreEqual(result.Description, addBookCommand.Description);
            Assert.AreEqual(result.Price, addBookCommand.Price);
        }

        [Test]
        public async Task AddUserBookAsync_SendAddUserBookCommand_Returns_AddedUserBook()
        {
            var userService = _serviceProvider.GetRequiredService<IUserService>();
            var addUserBookCommand = new AddUserBookCommand() { UserId = userId, BookId = bookId };
            var result = await userService.AddUserBookAsync(addUserBookCommand, default);
            userBookId = result.Id;

            Assert.NotNull(result, "Add user book failed");
            Assert.AreEqual(result.UserId, addUserBookCommand.UserId);
            Assert.AreEqual(result.BookId, addUserBookCommand.BookId);
        }

        [Test]
        public async Task UpdateUserBookAsync_SendUpdateUserBookCommand_Returns_UpdatedUserBook()
        {
            var userService = _serviceProvider.GetRequiredService<IUserService>();
            var updateUserBookCommand = new UpdateUserBookCommand() { Id = userBookId, UserId = userId, BookId = bookId };
            var result = await userService.UpdateUserBookAsync(updateUserBookCommand, default);

            Assert.NotNull(result, "Update user book failed");
            Assert.AreEqual(result.Id, updateUserBookCommand.Id);
            Assert.AreEqual(result.UserId, updateUserBookCommand.UserId);
            Assert.AreEqual(result.BookId, updateUserBookCommand.BookId);
        }

        [Test]
        public async Task UpdateHaveReadAsync_SendUpdateHaveReadCommand_Returns_UpdatedHaveRead()
        {
            var userService = _serviceProvider.GetRequiredService<IUserService>();
            var updateHaveReadCommand = new UpdateHaveReadCommand() { UserId = userId, BookId = bookId, HaveRead = true };
            var result = await userService.UpdateHaveReadAsync(updateHaveReadCommand, default);

            Assert.NotNull(result, "Update user book failed");
            Assert.AreEqual(result.UserId, updateHaveReadCommand.UserId);
            Assert.AreEqual(result.BookId, updateHaveReadCommand.BookId);
            Assert.AreEqual(result.HaveRead, updateHaveReadCommand.HaveRead);
        }
    }
}
