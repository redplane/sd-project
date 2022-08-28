using SdProject.Businesses.Services.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;
using SdProject.Businesses.Models.Users;
using SdProject.Core.DbContexts;
using Core.Entities;
using System.Collections.Generic;
using System.Linq;
using SdProject.Businesses.Exception;
using Microsoft.EntityFrameworkCore;

namespace SdProject.Businesses.Services
{
    public class BookService : IBookService
    {
        SdPDbContext _context;
        public BookService(SdPDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> SearchBookAsync(SearchBookQuery request, CancellationToken cancellation)
        {
            var books = _context.Book.AsQueryable();
            if (request != null && !string.IsNullOrWhiteSpace(request.Title))
            {
                books = books.Where(x => x.Title.Contains(request.Title));
            }

            if (request != null && !string.IsNullOrWhiteSpace(request.Category))
            {
                books = books.Where(x => x.Category.Contains(request.Category));
            }

            if (request != null && !string.IsNullOrWhiteSpace(request.Description))
            {
                books = books.Where(x => x.Description.Contains(request.Description));
            }

            return books.ToList();
        }

        public async Task<IEnumerable<Book>> FindBookByUserAsync(SearchBookByUserQuery request, CancellationToken cancellation)
        {
            return (from ub in _context.UserBookEntities
                    join b in _context.Book on ub.BookId equals b.Id
                    where ub.UserId == request.UserId
                    select new Book
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Category = b.Category,
                        Description = b.Description,
                        Price = b.Price
                    }).ToList();
        }

        public async Task<Book> AddBookAsync(AddBookCommand request, CancellationToken cancellation)
        {
            Book entity = new Book { Title = request.Title, Category = request.Category, Description = request.Description, Price = request.Price };
            var book = _context.Book.Add(entity);
            await _context.SaveChangesAsync();
            return book.Entity;
        }

        public async Task<Book> UpdateBookAsync(UpdateBookCommand request, CancellationToken cancellation)
        {
            var checkExists = _context.Book.AsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            if (checkExists == null)
            {
                throw new EntityNotFoundException(request.Id.ToString());
            }

            Book entity = new Book { Id = request.Id, Title = request.Title, Category = request.Category, Description = request.Description, Price = request.Price };
            var book = _context.Book.Update(entity);
            await _context.SaveChangesAsync();
            return book.Entity;
        }
    }
}