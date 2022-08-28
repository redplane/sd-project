using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SdProject.Businesses.Models.Users;
using SdProject.Businesses.Services;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.DbContexts;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SdProject.Businesses.Tests.BookServiceTests
{
    [TestFixture]
    public class AddBookAsyncTests
    {
        private IServiceProvider _serviceProvider;
        private int bookId;

        [SetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<SdPDbContext>();

            services.AddDbContext<SdPDbContext>(options =>
    options.UseInMemoryDatabase(databaseName: "SdProjectDB"));

            services.AddScoped<SdPDbContext>();
            _serviceProvider = services.BuildServiceProvider();
        }

        [Test]
        public async Task AddBookAsync_SendAddBookCommand_Returns_AddedBook()
        {
            var bookService = _serviceProvider.GetRequiredService<IBookService>();
            var addBookCommand = new AddBookCommand() { Title = "Book-2808-1", Category = "Category", Description = "Description", Price = 155000 };
            var result = await bookService.AddBookAsync(addBookCommand, default);
            bookId = result.Id;
            Assert.NotNull(result, "Add book failed");
        }

        [Test]
        public async Task UpdateBookAsync_SendUpdateBookCommand_Returns_UpdatedBook()
        {
            var bookService = _serviceProvider.GetRequiredService<IBookService>();
            var updateBookCommand = new UpdateBookCommand() { Id = bookId, Title = "Book-2808-2", Category = "Category-2", Description = "Description-2", Price = 165000 };
            var result = await bookService.UpdateBookAsync(updateBookCommand, default);

            Assert.NotNull(result, "Update book failed");
        }
    }
}
