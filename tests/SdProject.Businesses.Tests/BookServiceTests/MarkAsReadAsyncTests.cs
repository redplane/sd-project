using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SdProject.Businesses.Cqrs.Commands.Books;
using SdProject.Businesses.Cqrs.Commands.Users;
using SdProject.Businesses.Models.Exceptions;
using SdProject.Businesses.Services;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.DbContexts;

namespace SdProject.Businesses.Tests.BookServiceTests
{
    [TestFixture]
    public class MarkAsReadAsyncTests
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
        public void MarkAsReadAsync_BookNotExist_Throws_BookNotFoundException()
        {
            var bookService = _serviceProvider.GetRequiredService<IBookService>();
            var markAsReadCommand = new MarkBookAsReadCommand();
            markAsReadCommand.UserId = 1;
            markAsReadCommand.BookId = 1;

            var thrownException = Assert.CatchAsync<BookNotFoundException>(async () => await bookService.MarkAsReadAsync(markAsReadCommand));
            Assert.NotNull(thrownException);
        }
    }
}