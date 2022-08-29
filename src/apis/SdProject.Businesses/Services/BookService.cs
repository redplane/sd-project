using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SdProject.Businesses.Cqrs.Commands.Books;
using SdProject.Businesses.Cqrs.Commands.Users;
using SdProject.Businesses.Cqrs.Queries.Books;
using SdProject.Businesses.Models.Exceptions;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.DbContexts;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Services
{
    public class BookService : IBookService
    {
        #region Properties

        private readonly SdProjectDbContext _context;

        #endregion

        #region Constructor

        public BookService(SdProjectDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Method

        public async Task<IEnumerable<Book>> SearchAsync(SearchBookQuery request, CancellationToken cancellationToken)
        {
            var books = _context.Books.AsQueryable();
            if (request != null && !string.IsNullOrWhiteSpace(request.Title))
                books = books.Where(x => x.Title.Contains(request.Title));

            if (request != null && !string.IsNullOrWhiteSpace(request.Category))
                books = books.Where(x => x.Category.Contains(request.Category));

            if (request != null && !string.IsNullOrWhiteSpace(request.Description))
                books = books.Where(x => x.Description.Contains(request.Description));

            return await books.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Book>> SearchByUserAsync(SearchBookByUserQuery query,
            CancellationToken cancellationToken)
        {
            var userBooks = _context.UserBooks.AsQueryable();
            var books = _context.Books.AsQueryable();

            if (query.HaveRead != null)
                userBooks = userBooks.Where(x => x.HaveRead == query.HaveRead);

            return await (from ub in userBooks
                join b in books on ub.BookId equals b.Id
                where ub.UserId == query.UserId
                select new Book
                {
                    Id = b.Id,
                    Title = b.Title,
                    Category = b.Category,
                    Description = b.Description,
                    Price = b.Price
                }).ToListAsync(cancellationToken);
        }

        public async Task<Book> AddAsync(AddBookCommand request, CancellationToken cancellationToken)
        {
            var entity = new Book
            {
                Title = request.Title, Category = request.Category, Description = request.Description,
                Price = request.Price
            };
            var book = _context.Books.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return book.Entity;
        }

        public async Task<Book> UpdateAsync(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await GetByIdAsync(request.Id, cancellationToken);
            if (book == null)
                throw new BookNotFoundException();

            book.Title = request.Title;
            book.Category = request.Category;
            book.Description = request.Description;
            book.Price = request.Price;

            await _context.SaveChangesAsync(cancellationToken);
            return book;
        }

        public async Task MarkAsReadAsync(MarkBookAsReadCommand request, CancellationToken cancellationToken)
        {
            var book = await GetByIdAsync(request.BookId, cancellationToken);
            if (book == null)
                throw new BookNotFoundException();

            var userBook = await _context.UserBooks
                .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.BookId == request.BookId, cancellationToken);

            if (userBook == null)
                throw new UserBookNotFoundException();
            
            userBook.HaveRead = true;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var books = _context.Books;
            return await books.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        #endregion
    }
}