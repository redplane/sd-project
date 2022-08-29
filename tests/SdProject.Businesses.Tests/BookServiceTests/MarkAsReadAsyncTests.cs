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
        private ServiceCollection _services;
        
        [SetUp]
        public void SetUp()
        {
            _services = new ServiceCollection();
            _services.AddScoped<IBookService, BookService>();
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
        
        [Test]
        public void MarkAsReadAsync_BookNotExist_Throws_BookNotFoundException()
        {
            var serviceProvider = _services.BuildServiceProvider();
            
            var bookService = serviceProvider.GetRequiredService<IBookService>();
            var markAsReadCommand = new MarkBookAsReadCommand();
            markAsReadCommand.UserId = 1;
            markAsReadCommand.BookId = 1;

            var thrownException = Assert.CatchAsync<BookNotFoundException>(() => bookService.MarkAsReadAsync(markAsReadCommand));
            Assert.NotNull(thrownException);
        }
    }
}