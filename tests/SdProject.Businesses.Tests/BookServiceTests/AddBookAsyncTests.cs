using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SdProject.Businesses.Cqrs.Commands.Books;
using SdProject.Businesses.Services;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.DbContexts;

namespace SdProject.Businesses.Tests.BookServiceTests
{
    [TestFixture]
    public class AddBookAsyncTests
    {
        [SetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<SdProjectDbContext>();

            services.AddDbContext<SdProjectDbContext>(options =>
                options.UseInMemoryDatabase("SdProjectDB"));

            services.AddScoped<SdProjectDbContext>();
            _serviceProvider = services.BuildServiceProvider();
        }

        private IServiceProvider _serviceProvider;

        [Test]
        public async Task AddBookAsync_SendAddBookCommand_Returns_AddedBook()
        {
            var bookService = _serviceProvider.GetRequiredService<IBookService>();
            var addBookCommand = new AddBookCommand
                { Title = "Book-2808-1", Category = "Category", Description = "Description", Price = 155000 };
            var addedBook = await bookService.AddAsync(addBookCommand, default);
            
            Assert.NotNull(addedBook, "Add book failed");
            Assert.AreEqual(addedBook.Title, addBookCommand.Title);
            Assert.AreEqual(addedBook.Category, addBookCommand.Category);
            Assert.AreEqual(addedBook.Description, addBookCommand.Description);
            Assert.AreEqual(addedBook.Price, addBookCommand.Price);
        }
    }
}